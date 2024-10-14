using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMind.Eye;

namespace MechMindCameraTest
{
    public partial class MainForm : Form
    {

        private MechMindCamera _mechMindCamera;
        public MainForm()
        {
            InitializeComponent();
            _mechMindCamera = new MechMindCamera();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIpAddress.Text;
            bool isConnected = string.IsNullOrEmpty(ipAddress) ? _mechMindCamera.Connect() : _mechMindCamera.Connect(ipAddress);

            txtStatus.Text = isConnected ? "Connected successfully." : "Failed to connect.";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _mechMindCamera.Disconnect();
            txtStatus.Text = "Disconnected.";
        }

        private void btnCapturePointCloud_Click(object sender, EventArgs e)
        {
            string untexturedFilePath = "PointCloud.pcd";
            string texturedFilePath = "TexturedPointCloud.pcd";

            bool isCaptured = _mechMindCamera.CapturePointCloud(untexturedFilePath, texturedFilePath);
            txtStatus.Text = isCaptured ? "Point cloud captured successfully." : "Failed to capture point cloud.";
        }

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            _mechMindCamera.SetParameter("Exposure", 100); // Example parameter setting
            txtStatus.Text = "Parameter set.";
        }
    }
}
