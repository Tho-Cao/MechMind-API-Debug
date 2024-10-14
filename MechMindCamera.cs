using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMind.Eye;

namespace MechMindCameraTest
{
    /// <summary>
    /// Represents the scanning parameters for the camera.
    /// </summary>
    public enum CameraScanningParameter
    {
        ExposureMode
    }

    /// <summary>
    /// Represents the point cloud processing parameters for the camera.
    /// </summary>
    public enum PointCloudProcessingParameter
    {
        SurfaceSmoothing,
        NoiseRemoval,
        OutlierRemoval,
        EdgePreservation
    }

    /// <remarks>
    /// This class relies on the Camera class from the MMind.Eye namespace.
    /// It has methods to connect to the camera, either with or without an IP address.
    /// It also has methods to disconnect from the camera, capture point clouds, and set scanning and point cloud processing parameters.
    /// The connection state is maintained using a private flag.
    /// </remarks>
    public class MechMindCamera
    {
        private Camera _camera;
        private bool _isConnected;

        public MechMindCamera()
        {
            _camera = new Camera();
            _isConnected = false; // Initialize the flag
        }

        // Connect without IP address (default connection)
        public bool Connect()
        {
            bool result = Utils.FindAndConnect(ref _camera);
            _isConnected = result;
            return result;
        }

        // Connect with IP address
        public bool Connect(string ipAddress)
        {
            var result = _camera.Connect(ipAddress);
            Utils.ShowError(result);
            if (!result.IsOK())
            {
                _isConnected = false;
                return false;
            }
            _isConnected = true;
            return true;
        }

        public void Disconnect()
        {
            if (!_isConnected)
            {
                Console.WriteLine("Camera is already disconnected.");
                return;
            }

            _camera.Disconnect();
            _isConnected = false;
            Console.WriteLine("Disconnected from the camera successfully.");
        }

        public bool CapturePointCloud(string untexturedFilePath, string texturedFilePath)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Camera is not connected.");
                return false;
            }

            var frame = new Frame2DAnd3D();
            var captureResult = _camera.Capture2DAnd3D(ref frame);

            if (!captureResult.IsOK())
            {
                Utils.ShowError(captureResult);
                return false;
            }

            var saveResult = frame.Frame3D().SaveUntexturedPointCloud(FileFormat.PCD, untexturedFilePath);
            if (!saveResult.IsOK())
            {
                Utils.ShowError(saveResult);
                return false;
            }

            Console.WriteLine("Capture and save the textured point cloud: {0}", texturedFilePath);

            return true;
        }

        public bool CapturePointCloudWithNormal(string untexturedFilePath, string texturedFilePath)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Camera is not connected.");
                return false;
            }

            // Calculate the normals of the points on the camera and save the point cloud with normals to file
            var frame2DAnd3D = new Frame2DAnd3D();
            if (_camera.Capture2DAnd3DWithNormal(ref frame2DAnd3D).IsOK())
            {
                Utils.ShowError(frame2DAnd3D.Frame3D().SaveUntexturedPointCloudWithNormals(FileFormat.PLY, untexturedFilePath));
                Utils.ShowError(frame2DAnd3D.SaveTexturedPointCloudWithNormals(FileFormat.PLY, texturedFilePath));
            }
            else
            {
                Console.WriteLine("Failed to capture the point cloud.");
                return false;
            }

            Console.WriteLine("Capture and save the point clouds with normals successfully.");
            return true;
        }

        public void SetScanningParameters(CameraScanningParameter parameter, object value)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Camera is not connected.");
                return;
            }

            var userSetManager = _camera.UserSetManager();
            var currentUserSet = userSetManager.CurrentUserSet();

            switch (parameter)
            {
                case CameraScanningParameter.ExposureMode:
                    var exposureModeName = MMind.Eye.Scanning2DSetting.ExposureMode.Name;
                    Utils.ShowError(currentUserSet.SetEnumValue(exposureModeName, (int)value));
                    Console.WriteLine("Set Exposure Mode to {0}", value);
                    break;

                default:
                    Console.WriteLine("Unknown parameter: {0}", parameter);
                    break;
            }

            // Save all the parameter settings to the currently selected user set.
            Utils.ShowError(currentUserSet.SaveAllParametersToDevice());
            Console.WriteLine("Saved the current parameter settings to the selected user set.");
        }

        public void SetPointCloudProcessingParameters(PointCloudProcessingParameter parameter, object value)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Camera is not connected.");
                return;
            }

            var userSetManager = _camera.UserSetManager();
            var currentUserSet = userSetManager.CurrentUserSet();

            switch (parameter)
            {
                case PointCloudProcessingParameter.SurfaceSmoothing:
                    var surfaceSmoothingName = MMind.Eye.PointCloudProcessingSetting.SurfaceSmoothing.Name;
                    Utils.ShowError(currentUserSet.SetEnumValue(surfaceSmoothingName, (int)value));
                    Console.WriteLine("Set Surface Smoothing to {0}", value);
                    break;

                case PointCloudProcessingParameter.NoiseRemoval:
                    var noiseRemovalName = MMind.Eye.PointCloudProcessingSetting.NoiseRemoval.Name;
                    Utils.ShowError(currentUserSet.SetEnumValue(noiseRemovalName, (int)value));
                    Console.WriteLine("Set Noise Removal to {0}", value);
                    break;

                case PointCloudProcessingParameter.OutlierRemoval:
                    var outlierRemovalName = MMind.Eye.PointCloudProcessingSetting.OutlierRemoval.Name;
                    Utils.ShowError(currentUserSet.SetEnumValue(outlierRemovalName, (int)value));
                    Console.WriteLine("Set Outlier Removal to {0}", value);
                    break;

                case PointCloudProcessingParameter.EdgePreservation:
                    var edgePreservationName = MMind.Eye.PointCloudProcessingSetting.EdgePreservation.Name;
                    Utils.ShowError(currentUserSet.SetEnumValue(edgePreservationName, (int)value));
                    Console.WriteLine("Set Edge Preservation to {0}", value);
                    break;

                default:
                    Console.WriteLine("Unknown parameter: {0}", parameter);
                    break;
            }

            // Save all the parameter settings to the currently selected user set.
            Utils.ShowError(currentUserSet.SaveAllParametersToDevice());
            Console.WriteLine("Saved the current parameter settings to the selected user set.");
        }
    }
}
