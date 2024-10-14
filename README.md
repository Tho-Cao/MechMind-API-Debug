# MechMind-API-Debug
This Repo aims to develop API functions to interacting with Mech-Mind Scanner 

# Class
MechMindCameraTest
    ├── CameraScanningParameter
    │   └── ExposureMode
    ├── PointCloudProcessingParameter
    │   ├── SurfaceSmoothing
    │   ├── NoiseRemoval
    │   ├── OutlierRemoval
    │   └── EdgePreservation
    └── MechMindCamera
        ├── Fields
        │   ├── private Camera _camera
        │   └── private bool _isConnected
        ├── Constructor
        │   └── public MechMindCamera()
        └── Methods
            ├── public bool Connect()
            ├── public bool Connect(string ipAddress)
            ├── public void Disconnect()
            ├── public bool CapturePointCloud(string untexturedFilePath, string texturedFilePath)
            ├── public bool CapturePointCloudWithNormal(string untexturedFilePath, string texturedFilePath)
            ├── public void SetScanningParameters(CameraScanningParameter parameter, object value)
            └── public void SetPointCloudProcessingParameters(PointCloudProcessingParameter parameter, object value)

