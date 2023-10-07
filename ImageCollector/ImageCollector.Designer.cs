namespace StereoImage;

partial class ImageCollector
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        LiveCamImage = new PictureBox();
        CbbSourceCamera = new ComboBox();
        LblCameraInfo1 = new Label();
        CbbCalibrations = new ComboBox();
        LblCalibrations = new Label();
        TxtObjectName = new TextBox();
        LblTriangulationResult = new Label();
        CbbCameraResolution = new ComboBox();
        LblLiveImage = new Label();
        BtnStartProcess = new Button();
        TxtImageAngle = new TextBox();
        LblImageAngle = new Label();
        LblSerialPort = new Label();
        CbbSerialPort = new ComboBox();
        BtnTestSerialPort = new Button();
        LblProcessStatus = new Label();
        TrbFocus = new TrackBar();
        LblFocus = new Label();
        ((System.ComponentModel.ISupportInitialize)LiveCamImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)TrbFocus).BeginInit();
        SuspendLayout();
        // 
        // LiveCamImage
        // 
        LiveCamImage.Location = new Point(12, 32);
        LiveCamImage.Name = "LiveCamImage";
        LiveCamImage.Size = new Size(320, 180);
        LiveCamImage.SizeMode = PictureBoxSizeMode.Zoom;
        LiveCamImage.TabIndex = 1;
        LiveCamImage.TabStop = false;
        // 
        // CbbSourceCamera
        // 
        CbbSourceCamera.DropDownStyle = ComboBoxStyle.DropDownList;
        CbbSourceCamera.FormattingEnabled = true;
        CbbSourceCamera.Location = new Point(12, 220);
        CbbSourceCamera.Name = "CbbSourceCamera";
        CbbSourceCamera.Size = new Size(320, 23);
        CbbSourceCamera.TabIndex = 10;
        CbbSourceCamera.SelectedIndexChanged += CbbSourceCamera_SelectedIndexChanged;
        // 
        // LblCameraInfo1
        // 
        LblCameraInfo1.AutoSize = true;
        LblCameraInfo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCameraInfo1.Location = new Point(360, 32);
        LblCameraInfo1.Name = "LblCameraInfo1";
        LblCameraInfo1.Size = new Size(150, 15);
        LblCameraInfo1.TabIndex = 2;
        LblCameraInfo1.Text = "Camera and Platform Info";
        // 
        // CbbCalibrations
        // 
        CbbCalibrations.DropDownStyle = ComboBoxStyle.DropDownList;
        CbbCalibrations.FormattingEnabled = true;
        CbbCalibrations.Location = new Point(360, 141);
        CbbCalibrations.Name = "CbbCalibrations";
        CbbCalibrations.Size = new Size(320, 23);
        CbbCalibrations.TabIndex = 23;
        // 
        // LblCalibrations
        // 
        LblCalibrations.AutoSize = true;
        LblCalibrations.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCalibrations.Location = new Point(360, 123);
        LblCalibrations.Name = "LblCalibrations";
        LblCalibrations.Size = new Size(66, 15);
        LblCalibrations.TabIndex = 24;
        LblCalibrations.Text = "Calibration";
        // 
        // TxtObjectName
        // 
        TxtObjectName.Location = new Point(360, 196);
        TxtObjectName.Name = "TxtObjectName";
        TxtObjectName.Size = new Size(320, 23);
        TxtObjectName.TabIndex = 29;
        // 
        // LblTriangulationResult
        // 
        LblTriangulationResult.AutoSize = true;
        LblTriangulationResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblTriangulationResult.Location = new Point(360, 178);
        LblTriangulationResult.Name = "LblTriangulationResult";
        LblTriangulationResult.Size = new Size(80, 15);
        LblTriangulationResult.TabIndex = 30;
        LblTriangulationResult.Text = "Object Name";
        // 
        // CbbCameraResolution
        // 
        CbbCameraResolution.DropDownStyle = ComboBoxStyle.DropDownList;
        CbbCameraResolution.FormattingEnabled = true;
        CbbCameraResolution.Location = new Point(12, 249);
        CbbCameraResolution.Name = "CbbCameraResolution";
        CbbCameraResolution.Size = new Size(320, 23);
        CbbCameraResolution.TabIndex = 31;
        CbbCameraResolution.SelectedIndexChanged += CbbCameraResolution_SelectedIndexChanged;
        // 
        // LblLiveImage
        // 
        LblLiveImage.AutoSize = true;
        LblLiveImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblLiveImage.Location = new Point(12, 14);
        LblLiveImage.Name = "LblLiveImage";
        LblLiveImage.Size = new Size(68, 15);
        LblLiveImage.TabIndex = 32;
        LblLiveImage.Text = "Live Image";
        // 
        // BtnStartProcess
        // 
        BtnStartProcess.Location = new Point(12, 427);
        BtnStartProcess.Name = "BtnStartProcess";
        BtnStartProcess.Size = new Size(668, 23);
        BtnStartProcess.TabIndex = 34;
        BtnStartProcess.Text = "Start Process";
        BtnStartProcess.UseVisualStyleBackColor = true;
        BtnStartProcess.Click += BtnStartProcess_Click;
        // 
        // TxtImageAngle
        // 
        TxtImageAngle.Location = new Point(360, 82);
        TxtImageAngle.Name = "TxtImageAngle";
        TxtImageAngle.Size = new Size(320, 23);
        TxtImageAngle.TabIndex = 36;
        TxtImageAngle.Text = "0.0";
        TxtImageAngle.TextAlign = HorizontalAlignment.Right;
        // 
        // LblImageAngle
        // 
        LblImageAngle.AutoSize = true;
        LblImageAngle.Location = new Point(360, 64);
        LblImageAngle.Name = "LblImageAngle";
        LblImageAngle.Size = new Size(127, 15);
        LblImageAngle.TabIndex = 35;
        LblImageAngle.Text = "Angle Between Images";
        // 
        // LblSerialPort
        // 
        LblSerialPort.AutoSize = true;
        LblSerialPort.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblSerialPort.Location = new Point(360, 231);
        LblSerialPort.Name = "LblSerialPort";
        LblSerialPort.Size = new Size(65, 15);
        LblSerialPort.TabIndex = 38;
        LblSerialPort.Text = "Serial Port";
        // 
        // CbbSerialPort
        // 
        CbbSerialPort.DropDownStyle = ComboBoxStyle.DropDownList;
        CbbSerialPort.FormattingEnabled = true;
        CbbSerialPort.Location = new Point(360, 249);
        CbbSerialPort.Name = "CbbSerialPort";
        CbbSerialPort.Size = new Size(215, 23);
        CbbSerialPort.TabIndex = 37;
        CbbSerialPort.SelectedIndexChanged += CbbSerialPort_SelectedIndexChanged;
        // 
        // BtnTestSerialPort
        // 
        BtnTestSerialPort.Location = new Point(581, 249);
        BtnTestSerialPort.Name = "BtnTestSerialPort";
        BtnTestSerialPort.Size = new Size(99, 23);
        BtnTestSerialPort.TabIndex = 39;
        BtnTestSerialPort.Text = "Test Port";
        BtnTestSerialPort.UseVisualStyleBackColor = true;
        BtnTestSerialPort.Click += BtnTestSerialPort_Click;
        // 
        // LblProcessStatus
        // 
        LblProcessStatus.Location = new Point(12, 403);
        LblProcessStatus.Name = "LblProcessStatus";
        LblProcessStatus.Size = new Size(668, 21);
        LblProcessStatus.TabIndex = 40;
        LblProcessStatus.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // TrbFocus
        // 
        TrbFocus.Location = new Point(12, 307);
        TrbFocus.Maximum = 100;
        TrbFocus.Name = "TrbFocus";
        TrbFocus.Size = new Size(320, 45);
        TrbFocus.TabIndex = 41;
        TrbFocus.Scroll += TrbFocus_Scroll;
        // 
        // LblFocus
        // 
        LblFocus.AutoSize = true;
        LblFocus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblFocus.Location = new Point(15, 289);
        LblFocus.Name = "LblFocus";
        LblFocus.Size = new Size(56, 15);
        LblFocus.TabIndex = 42;
        LblFocus.Text = "Focus - 0";
        // 
        // ImageCollector
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(705, 476);
        Controls.Add(LblFocus);
        Controls.Add(TrbFocus);
        Controls.Add(LblProcessStatus);
        Controls.Add(BtnTestSerialPort);
        Controls.Add(LblSerialPort);
        Controls.Add(CbbSerialPort);
        Controls.Add(TxtImageAngle);
        Controls.Add(LblImageAngle);
        Controls.Add(BtnStartProcess);
        Controls.Add(LblLiveImage);
        Controls.Add(CbbCameraResolution);
        Controls.Add(LblTriangulationResult);
        Controls.Add(TxtObjectName);
        Controls.Add(LblCalibrations);
        Controls.Add(CbbCalibrations);
        Controls.Add(CbbSourceCamera);
        Controls.Add(LblCameraInfo1);
        Controls.Add(LiveCamImage);
        Name = "ImageCollector";
        Text = "Camera - Fotogrametria";
        ((System.ComponentModel.ISupportInitialize)LiveCamImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)TrbFocus).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox CbbSourceCamera;

    private PictureBox LiveCamImage;
    private Label LblCameraInfo1;
    private ComboBox CbbCalibrations;
    private Label LblCalibrations;
    private TextBox TxtObjectName;
    private Label LblTriangulationResult;
    private ComboBox CbbCameraResolution;
    private Label LblLiveImage;
    private Button BtnStartProcess;
    private TextBox TxtImageAngle;
    private Label LblImageAngle;
    private Label LblSerialPort;
    private ComboBox CbbSerialPort;
    private Button BtnTestSerialPort;
    private Label LblProcessStatus;
    private TrackBar TrbFocus;
    private Label LblFocus;
}
