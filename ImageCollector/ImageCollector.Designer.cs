﻿namespace StereoImage;

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
        LblCameraDistance = new Label();
        TxtCameraDistance = new TextBox();
        TxtCameraAngle = new TextBox();
        LblCameraAngle = new Label();
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
        ((System.ComponentModel.ISupportInitialize)LiveCamImage).BeginInit();
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
        // LblCameraDistance
        // 
        LblCameraDistance.AutoSize = true;
        LblCameraDistance.Location = new Point(360, 51);
        LblCameraDistance.Name = "LblCameraDistance";
        LblCameraDistance.Size = new Size(145, 15);
        LblCameraDistance.TabIndex = 3;
        LblCameraDistance.Text = "Distance from object (cm)";
        // 
        // TxtCameraDistance
        // 
        TxtCameraDistance.Location = new Point(360, 69);
        TxtCameraDistance.Name = "TxtCameraDistance";
        TxtCameraDistance.Size = new Size(320, 23);
        TxtCameraDistance.TabIndex = 4;
        TxtCameraDistance.Text = "0.0";
        TxtCameraDistance.TextAlign = HorizontalAlignment.Right;
        // 
        // TxtCameraAngle
        // 
        TxtCameraAngle.Location = new Point(360, 124);
        TxtCameraAngle.Name = "TxtCameraAngle";
        TxtCameraAngle.Size = new Size(320, 23);
        TxtCameraAngle.TabIndex = 6;
        TxtCameraAngle.Text = "0.0";
        TxtCameraAngle.TextAlign = HorizontalAlignment.Right;
        // 
        // LblCameraAngle
        // 
        LblCameraAngle.AutoSize = true;
        LblCameraAngle.Location = new Point(360, 106);
        LblCameraAngle.Name = "LblCameraAngle";
        LblCameraAngle.Size = new Size(82, 15);
        LblCameraAngle.TabIndex = 5;
        LblCameraAngle.Text = "Camera Angle";
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
        CbbCalibrations.Location = new Point(360, 246);
        CbbCalibrations.Name = "CbbCalibrations";
        CbbCalibrations.Size = new Size(320, 23);
        CbbCalibrations.TabIndex = 23;
        // 
        // LblCalibrations
        // 
        LblCalibrations.AutoSize = true;
        LblCalibrations.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCalibrations.Location = new Point(360, 228);
        LblCalibrations.Name = "LblCalibrations";
        LblCalibrations.Size = new Size(66, 15);
        LblCalibrations.TabIndex = 24;
        LblCalibrations.Text = "Calibration";
        // 
        // TxtObjectName
        // 
        TxtObjectName.Location = new Point(360, 307);
        TxtObjectName.Name = "TxtObjectName";
        TxtObjectName.Size = new Size(320, 23);
        TxtObjectName.TabIndex = 29;
        // 
        // LblTriangulationResult
        // 
        LblTriangulationResult.AutoSize = true;
        LblTriangulationResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblTriangulationResult.Location = new Point(360, 289);
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
        BtnStartProcess.Location = new Point(12, 389);
        BtnStartProcess.Name = "BtnStartProcess";
        BtnStartProcess.Size = new Size(668, 23);
        BtnStartProcess.TabIndex = 34;
        BtnStartProcess.Text = "Start Process";
        BtnStartProcess.UseVisualStyleBackColor = true;
        BtnStartProcess.Click += BtnStartProcess_Click;
        // 
        // TxtImageAngle
        // 
        TxtImageAngle.Location = new Point(360, 182);
        TxtImageAngle.Name = "TxtImageAngle";
        TxtImageAngle.Size = new Size(320, 23);
        TxtImageAngle.TabIndex = 36;
        TxtImageAngle.Text = "0.0";
        TxtImageAngle.TextAlign = HorizontalAlignment.Right;
        // 
        // LblImageAngle
        // 
        LblImageAngle.AutoSize = true;
        LblImageAngle.Location = new Point(360, 164);
        LblImageAngle.Name = "LblImageAngle";
        LblImageAngle.Size = new Size(127, 15);
        LblImageAngle.TabIndex = 35;
        LblImageAngle.Text = "Angle Between Images";
        // 
        // LblSerialPort
        // 
        LblSerialPort.AutoSize = true;
        LblSerialPort.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblSerialPort.Location = new Point(12, 289);
        LblSerialPort.Name = "LblSerialPort";
        LblSerialPort.Size = new Size(65, 15);
        LblSerialPort.TabIndex = 38;
        LblSerialPort.Text = "Serial Port";
        // 
        // CbbSerialPort
        // 
        CbbSerialPort.DropDownStyle = ComboBoxStyle.DropDownList;
        CbbSerialPort.FormattingEnabled = true;
        CbbSerialPort.Location = new Point(12, 307);
        CbbSerialPort.Name = "CbbSerialPort";
        CbbSerialPort.Size = new Size(215, 23);
        CbbSerialPort.TabIndex = 37;
        CbbSerialPort.SelectedIndexChanged += CbbSerialPort_SelectedIndexChanged;
        // 
        // BtnTestSerialPort
        // 
        BtnTestSerialPort.Location = new Point(233, 306);
        BtnTestSerialPort.Name = "BtnTestSerialPort";
        BtnTestSerialPort.Size = new Size(99, 23);
        BtnTestSerialPort.TabIndex = 39;
        BtnTestSerialPort.Text = "Test Port";
        BtnTestSerialPort.UseVisualStyleBackColor = true;
        BtnTestSerialPort.Click += BtnTestSerialPort_Click;
        // 
        // LblProcessStatus
        // 
        LblProcessStatus.Location = new Point(12, 353);
        LblProcessStatus.Name = "LblProcessStatus";
        LblProcessStatus.Size = new Size(668, 21);
        LblProcessStatus.TabIndex = 40;
        LblProcessStatus.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ImageCollector
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(704, 433);
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
        Controls.Add(TxtCameraAngle);
        Controls.Add(LblCameraAngle);
        Controls.Add(TxtCameraDistance);
        Controls.Add(LblCameraDistance);
        Controls.Add(LblCameraInfo1);
        Controls.Add(LiveCamImage);
        Name = "ImageCollector";
        Text = "Camera - Fotogrametria";
        ((System.ComponentModel.ISupportInitialize)LiveCamImage).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }



    #endregion
    private Label LblCameraDistance;
    private Label LblCameraAngle;

    private TextBox TxtCameraDistance;
    private TextBox TxtCameraAngle;

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
}
