using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMind.Eye;

namespace MechMindCameraTest
{
    public class MechMindCamera
    {
        private Camera _camera;
        public MechMindCamera()
        {
            _camera = new Camera();
        }
        // Connect without IP address (default connection)
        public bool Connect()
        {
            return Utils.FindAndConnect(ref _camera);
        }
        // Connect with IP address
        public bool Connect(string ipAddress)
        {
            var result = _camera.Connect(ipAddress);
            Utils.ShowError(result);
            if (!result.IsOK())
            {
                return false;
            }
            return true;
        }
        public void Disconnect()
        {
            _camera.Disconnect();
            Console.WriteLine("Disconnected from the camera successfully.");
        }

        public bool CapturePointCloud(string untexturedFilePath, string texturedFilePath)
        {
            if (!Utils.ConfirmCapture3D())
            {
                Disconnect();
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

        public void SetParameter(string parameterName, object value)
        {
            // Implement the logic to set camera parameters
            // Example: _camera.SetParameter(parameterName, value);
            Console.WriteLine("Set parameter {0} to {1}", parameterName, value);
        }
        public bool CapturePointCloudWithNormal(string untexturedFilePath, string texturedFilePath)
        {
            if (!Utils.ConfirmCapture3D())
            {
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

    }
}
