namespace MechMindCameraTest
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnCapturePointCloud;
        private System.Windows.Forms.Button btnSetParameter;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnCapturePointCloud = new System.Windows.Forms.Button();
            this.btnSetParameter = new System.Windows.Forms.Button();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(93, 20);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(347, 22);
            this.txtIpAddress.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(93, 60);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(347, 114);
            this.txtStatus.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(20, 180);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(120, 180);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnCapturePointCloud
            // 
            this.btnCapturePointCloud.Location = new System.Drawing.Point(220, 180);
            this.btnCapturePointCloud.Name = "btnCapturePointCloud";
            this.btnCapturePointCloud.Size = new System.Drawing.Size(100, 23);
            this.btnCapturePointCloud.TabIndex = 4;
            this.btnCapturePointCloud.Text = "Capture Point Cloud";
            this.btnCapturePointCloud.UseVisualStyleBackColor = true;
            this.btnCapturePointCloud.Click += new System.EventHandler(this.btnCapturePointCloud_Click);
            // 
            // btnSetParameter
            // 
            this.btnSetParameter.Location = new System.Drawing.Point(340, 180);
            this.btnSetParameter.Name = "btnSetParameter";
            this.btnSetParameter.Size = new System.Drawing.Size(100, 23);
            this.btnSetParameter.TabIndex = 5;
            this.btnSetParameter.Text = "Set Parameter";
            this.btnSetParameter.UseVisualStyleBackColor = true;
            this.btnSetParameter.Click += new System.EventHandler(this.btnSetParameter_Click);
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.AutoSize = true;
            this.lblIpAddress.Location = new System.Drawing.Point(20, 20);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(73, 16);
            this.lblIpAddress.TabIndex = 6;
            this.lblIpAddress.Text = "IP Address";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(451, 221);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblIpAddress);
            this.Controls.Add(this.btnSetParameter);
            this.Controls.Add(this.btnCapturePointCloud);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtIpAddress);
            this.Name = "MainForm";
            this.Text = "MechMind Camera Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

