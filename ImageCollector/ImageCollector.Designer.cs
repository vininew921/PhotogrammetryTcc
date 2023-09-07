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
        LblCameraDistance = new Label();
        TxtCameraDistance = new TextBox();
        TxtCameraAngle = new TextBox();
        LblCameraAngle = new Label();
        CbbSourceCamera = new ComboBox();
        PbProcessedImage = new PictureBox();
        LblCameraInfo1 = new Label();
        CbbCalibrations = new ComboBox();
        LblCalibrations = new Label();
        BtnReset = new Button();
        LblCameraMatrix = new Label();
        LblCameraMatrixValue = new Label();
        TxtObjectName = new TextBox();
        LblTriangulationResult = new Label();
        CbbCameraResolution = new ComboBox();
        LblLiveImage = new Label();
        LblProcessedImage = new Label();
        BtnStartProcess = new Button();
        TxtImageAngle = new TextBox();
        LblImageAngle = new Label();
        ((System.ComponentModel.ISupportInitialize)LiveCamImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbProcessedImage).BeginInit();
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
        LblCameraDistance.Location = new Point(12, 592);
        LblCameraDistance.Name = "LblCameraDistance";
        LblCameraDistance.Size = new Size(145, 15);
        LblCameraDistance.TabIndex = 3;
        LblCameraDistance.Text = "Distance from object (cm)";
        // 
        // TxtCameraDistance
        // 
        TxtCameraDistance.Location = new Point(12, 610);
        TxtCameraDistance.Name = "TxtCameraDistance";
        TxtCameraDistance.Size = new Size(143, 23);
        TxtCameraDistance.TabIndex = 4;
        TxtCameraDistance.Text = "0.0";
        TxtCameraDistance.TextAlign = HorizontalAlignment.Right;
        // 
        // TxtCameraAngle
        // 
        TxtCameraAngle.Location = new Point(12, 665);
        TxtCameraAngle.Name = "TxtCameraAngle";
        TxtCameraAngle.Size = new Size(143, 23);
        TxtCameraAngle.TabIndex = 6;
        TxtCameraAngle.Text = "0.0";
        TxtCameraAngle.TextAlign = HorizontalAlignment.Right;
        // 
        // LblCameraAngle
        // 
        LblCameraAngle.AutoSize = true;
        LblCameraAngle.Location = new Point(12, 647);
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
        // PbProcessedImage
        // 
        PbProcessedImage.Location = new Point(398, 117);
        PbProcessedImage.Name = "PbProcessedImage";
        PbProcessedImage.Size = new Size(864, 486);
        PbProcessedImage.SizeMode = PictureBoxSizeMode.Zoom;
        PbProcessedImage.TabIndex = 11;
        PbProcessedImage.TabStop = false;
        // 
        // LblCameraInfo1
        // 
        LblCameraInfo1.AutoSize = true;
        LblCameraInfo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCameraInfo1.Location = new Point(12, 573);
        LblCameraInfo1.Name = "LblCameraInfo1";
        LblCameraInfo1.Size = new Size(150, 15);
        LblCameraInfo1.TabIndex = 2;
        LblCameraInfo1.Text = "Camera and Platform Info";
        // 
        // CbbCalibrations
        // 
        CbbCalibrations.DropDownStyle = ComboBoxStyle.DropDownList;
        CbbCalibrations.FormattingEnabled = true;
        CbbCalibrations.Location = new Point(12, 310);
        CbbCalibrations.Name = "CbbCalibrations";
        CbbCalibrations.Size = new Size(320, 23);
        CbbCalibrations.TabIndex = 23;
        CbbCalibrations.SelectedIndexChanged += CbbCalibrations_SelectedIndexChanged;
        // 
        // LblCalibrations
        // 
        LblCalibrations.AutoSize = true;
        LblCalibrations.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCalibrations.Location = new Point(12, 292);
        LblCalibrations.Name = "LblCalibrations";
        LblCalibrations.Size = new Size(66, 15);
        LblCalibrations.TabIndex = 24;
        LblCalibrations.Text = "Calibration";
        // 
        // BtnReset
        // 
        BtnReset.Location = new Point(1045, 639);
        BtnReset.Name = "BtnReset";
        BtnReset.Size = new Size(217, 23);
        BtnReset.TabIndex = 25;
        BtnReset.Text = "Reset";
        BtnReset.UseVisualStyleBackColor = true;
        BtnReset.Click += BtnReset_Click;
        // 
        // LblCameraMatrix
        // 
        LblCameraMatrix.AutoSize = true;
        LblCameraMatrix.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCameraMatrix.Location = new Point(12, 359);
        LblCameraMatrix.Name = "LblCameraMatrix";
        LblCameraMatrix.Size = new Size(89, 15);
        LblCameraMatrix.TabIndex = 26;
        LblCameraMatrix.Text = "Camera Matrix";
        // 
        // LblCameraMatrixValue
        // 
        LblCameraMatrixValue.AutoSize = true;
        LblCameraMatrixValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblCameraMatrixValue.Location = new Point(12, 381);
        LblCameraMatrixValue.Name = "LblCameraMatrixValue";
        LblCameraMatrixValue.Size = new Size(37, 15);
        LblCameraMatrixValue.TabIndex = 27;
        LblCameraMatrixValue.Text = "value";
        // 
        // TxtObjectName
        // 
        TxtObjectName.Location = new Point(12, 525);
        TxtObjectName.Name = "TxtObjectName";
        TxtObjectName.Size = new Size(215, 23);
        TxtObjectName.TabIndex = 29;
        // 
        // LblTriangulationResult
        // 
        LblTriangulationResult.AutoSize = true;
        LblTriangulationResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblTriangulationResult.Location = new Point(12, 507);
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
        // LblProcessedImage
        // 
        LblProcessedImage.AutoSize = true;
        LblProcessedImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblProcessedImage.Location = new Point(398, 99);
        LblProcessedImage.Name = "LblProcessedImage";
        LblProcessedImage.Size = new Size(101, 15);
        LblProcessedImage.TabIndex = 33;
        LblProcessedImage.Text = "Processed Image";
        // 
        // BtnStartProcess
        // 
        BtnStartProcess.Location = new Point(398, 639);
        BtnStartProcess.Name = "BtnStartProcess";
        BtnStartProcess.Size = new Size(217, 23);
        BtnStartProcess.TabIndex = 34;
        BtnStartProcess.Text = "Start Process";
        BtnStartProcess.UseVisualStyleBackColor = true;
        BtnStartProcess.Click += BtnStartProcess_Click;
        // 
        // TxtImageAngle
        // 
        TxtImageAngle.Location = new Point(12, 723);
        TxtImageAngle.Name = "TxtImageAngle";
        TxtImageAngle.Size = new Size(143, 23);
        TxtImageAngle.TabIndex = 36;
        TxtImageAngle.Text = "0.0";
        TxtImageAngle.TextAlign = HorizontalAlignment.Right;
        // 
        // LblImageAngle
        // 
        LblImageAngle.AutoSize = true;
        LblImageAngle.Location = new Point(12, 705);
        LblImageAngle.Name = "LblImageAngle";
        LblImageAngle.Size = new Size(127, 15);
        LblImageAngle.TabIndex = 35;
        LblImageAngle.Text = "Angle Between Images";
        // 
        // ImageCollector
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1347, 819);
        Controls.Add(TxtImageAngle);
        Controls.Add(LblImageAngle);
        Controls.Add(BtnStartProcess);
        Controls.Add(LblProcessedImage);
        Controls.Add(LblLiveImage);
        Controls.Add(CbbCameraResolution);
        Controls.Add(LblTriangulationResult);
        Controls.Add(TxtObjectName);
        Controls.Add(LblCameraMatrixValue);
        Controls.Add(LblCameraMatrix);
        Controls.Add(BtnReset);
        Controls.Add(LblCalibrations);
        Controls.Add(CbbCalibrations);
        Controls.Add(PbProcessedImage);
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
        ((System.ComponentModel.ISupportInitialize)PbProcessedImage).EndInit();
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
    private PictureBox PbProcessedImage;
    private Label LblCameraInfo1;
    private ComboBox CbbCalibrations;
    private Label LblCalibrations;
    private Button BtnReset;
    private Label LblCameraMatrix;
    private Label LblCameraMatrixValue;
    private TextBox TxtObjectName;
    private Label LblTriangulationResult;
    private ComboBox CbbCameraResolution;
    private Label LblLiveImage;
    private Label LblProcessedImage;
    private Button BtnStartProcess;
    private TextBox TxtImageAngle;
    private Label LblImageAngle;
}
