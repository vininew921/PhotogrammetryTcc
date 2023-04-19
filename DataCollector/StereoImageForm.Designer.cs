namespace StereoImage;

partial class StereoImageForm
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
            this.LiveCamImage = new System.Windows.Forms.PictureBox();
            this.LblXAxis1 = new System.Windows.Forms.Label();
            this.TxtXAxis1 = new System.Windows.Forms.TextBox();
            this.TxtYAxis1 = new System.Windows.Forms.TextBox();
            this.LblYAxis1 = new System.Windows.Forms.Label();
            this.TxtZAxis1 = new System.Windows.Forms.TextBox();
            this.LblZAxis1 = new System.Windows.Forms.Label();
            this.CbbSourceCamera = new System.Windows.Forms.ComboBox();
            this.PbImage1 = new System.Windows.Forms.PictureBox();
            this.PbImage2 = new System.Windows.Forms.PictureBox();
            this.BtnCaptureImage = new System.Windows.Forms.Button();
            this.LblCameraInfo1 = new System.Windows.Forms.Label();
            this.TxtZAxis2 = new System.Windows.Forms.TextBox();
            this.LblZAxis2 = new System.Windows.Forms.Label();
            this.TxtYAxis2 = new System.Windows.Forms.TextBox();
            this.LblYAxis2 = new System.Windows.Forms.Label();
            this.TxtXAxis2 = new System.Windows.Forms.TextBox();
            this.LblXAxis2 = new System.Windows.Forms.Label();
            this.LblCameraInfo2 = new System.Windows.Forms.Label();
            this.CbbCalibrations = new System.Windows.Forms.ComboBox();
            this.LblCalibrations = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.LblCameraMatrix = new System.Windows.Forms.Label();
            this.LblCameraMatrixValue = new System.Windows.Forms.Label();
            this.BtnTriangulate = new System.Windows.Forms.Button();
            this.TxtObjectName = new System.Windows.Forms.TextBox();
            this.LblTriangulationResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LiveCamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage2)).BeginInit();
            this.SuspendLayout();
            // 
            // LiveCamImage
            // 
            this.LiveCamImage.Location = new System.Drawing.Point(12, 32);
            this.LiveCamImage.Name = "LiveCamImage";
            this.LiveCamImage.Size = new System.Drawing.Size(320, 180);
            this.LiveCamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LiveCamImage.TabIndex = 1;
            this.LiveCamImage.TabStop = false;
            // 
            // LblXAxis1
            // 
            this.LblXAxis1.AutoSize = true;
            this.LblXAxis1.Location = new System.Drawing.Point(1078, 58);
            this.LblXAxis1.Name = "LblXAxis1";
            this.LblXAxis1.Size = new System.Drawing.Size(14, 15);
            this.LblXAxis1.TabIndex = 3;
            this.LblXAxis1.Text = "X";
            // 
            // TxtXAxis1
            // 
            this.TxtXAxis1.Location = new System.Drawing.Point(1080, 76);
            this.TxtXAxis1.Name = "TxtXAxis1";
            this.TxtXAxis1.Size = new System.Drawing.Size(37, 23);
            this.TxtXAxis1.TabIndex = 4;
            this.TxtXAxis1.Text = "0.0";
            // 
            // TxtYAxis1
            // 
            this.TxtYAxis1.Location = new System.Drawing.Point(1127, 76);
            this.TxtYAxis1.Name = "TxtYAxis1";
            this.TxtYAxis1.Size = new System.Drawing.Size(37, 23);
            this.TxtYAxis1.TabIndex = 6;
            this.TxtYAxis1.Text = "0.0";
            // 
            // LblYAxis1
            // 
            this.LblYAxis1.AutoSize = true;
            this.LblYAxis1.Location = new System.Drawing.Point(1127, 58);
            this.LblYAxis1.Name = "LblYAxis1";
            this.LblYAxis1.Size = new System.Drawing.Size(14, 15);
            this.LblYAxis1.TabIndex = 5;
            this.LblYAxis1.Text = "Y";
            // 
            // TxtZAxis1
            // 
            this.TxtZAxis1.Location = new System.Drawing.Point(1170, 76);
            this.TxtZAxis1.Name = "TxtZAxis1";
            this.TxtZAxis1.Size = new System.Drawing.Size(37, 23);
            this.TxtZAxis1.TabIndex = 8;
            this.TxtZAxis1.Text = "0.0";
            // 
            // LblZAxis1
            // 
            this.LblZAxis1.AutoSize = true;
            this.LblZAxis1.Location = new System.Drawing.Point(1172, 58);
            this.LblZAxis1.Name = "LblZAxis1";
            this.LblZAxis1.Size = new System.Drawing.Size(14, 15);
            this.LblZAxis1.TabIndex = 7;
            this.LblZAxis1.Text = "Z";
            // 
            // CbbSourceCamera
            // 
            this.CbbSourceCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbSourceCamera.FormattingEnabled = true;
            this.CbbSourceCamera.Location = new System.Drawing.Point(12, 220);
            this.CbbSourceCamera.Name = "CbbSourceCamera";
            this.CbbSourceCamera.Size = new System.Drawing.Size(320, 23);
            this.CbbSourceCamera.TabIndex = 10;
            this.CbbSourceCamera.SelectedIndexChanged += new System.EventHandler(this.CbbSourceCamera_SelectedIndexChanged);
            // 
            // PbImage1
            // 
            this.PbImage1.Location = new System.Drawing.Point(407, 32);
            this.PbImage1.Name = "PbImage1";
            this.PbImage1.Size = new System.Drawing.Size(640, 360);
            this.PbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbImage1.TabIndex = 11;
            this.PbImage1.TabStop = false;
            this.PbImage1.Click += new System.EventHandler(this.PbImage1_Click);
            // 
            // PbImage2
            // 
            this.PbImage2.Location = new System.Drawing.Point(407, 408);
            this.PbImage2.Name = "PbImage2";
            this.PbImage2.Size = new System.Drawing.Size(640, 360);
            this.PbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbImage2.TabIndex = 14;
            this.PbImage2.TabStop = false;
            this.PbImage2.Click += new System.EventHandler(this.PbImage2_Click);
            // 
            // BtnCaptureImage
            // 
            this.BtnCaptureImage.Location = new System.Drawing.Point(12, 249);
            this.BtnCaptureImage.Name = "BtnCaptureImage";
            this.BtnCaptureImage.Size = new System.Drawing.Size(320, 23);
            this.BtnCaptureImage.TabIndex = 15;
            this.BtnCaptureImage.Text = "Capturar Imagem";
            this.BtnCaptureImage.UseVisualStyleBackColor = true;
            this.BtnCaptureImage.Click += new System.EventHandler(this.BtnCaptureImage_Click);
            // 
            // LblCameraInfo1
            // 
            this.LblCameraInfo1.AutoSize = true;
            this.LblCameraInfo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraInfo1.Location = new System.Drawing.Point(1080, 32);
            this.LblCameraInfo1.Name = "LblCameraInfo1";
            this.LblCameraInfo1.Size = new System.Drawing.Size(113, 15);
            this.LblCameraInfo1.TabIndex = 2;
            this.LblCameraInfo1.Text = "Camera Info 1 - cm";
            // 
            // TxtZAxis2
            // 
            this.TxtZAxis2.Location = new System.Drawing.Point(1170, 452);
            this.TxtZAxis2.Name = "TxtZAxis2";
            this.TxtZAxis2.Size = new System.Drawing.Size(37, 23);
            this.TxtZAxis2.TabIndex = 22;
            this.TxtZAxis2.Text = "0.0";
            // 
            // LblZAxis2
            // 
            this.LblZAxis2.AutoSize = true;
            this.LblZAxis2.Location = new System.Drawing.Point(1172, 434);
            this.LblZAxis2.Name = "LblZAxis2";
            this.LblZAxis2.Size = new System.Drawing.Size(14, 15);
            this.LblZAxis2.TabIndex = 21;
            this.LblZAxis2.Text = "Z";
            // 
            // TxtYAxis2
            // 
            this.TxtYAxis2.Location = new System.Drawing.Point(1127, 452);
            this.TxtYAxis2.Name = "TxtYAxis2";
            this.TxtYAxis2.Size = new System.Drawing.Size(37, 23);
            this.TxtYAxis2.TabIndex = 20;
            this.TxtYAxis2.Text = "0.0";
            // 
            // LblYAxis2
            // 
            this.LblYAxis2.AutoSize = true;
            this.LblYAxis2.Location = new System.Drawing.Point(1127, 434);
            this.LblYAxis2.Name = "LblYAxis2";
            this.LblYAxis2.Size = new System.Drawing.Size(14, 15);
            this.LblYAxis2.TabIndex = 19;
            this.LblYAxis2.Text = "Y";
            // 
            // TxtXAxis2
            // 
            this.TxtXAxis2.Location = new System.Drawing.Point(1080, 452);
            this.TxtXAxis2.Name = "TxtXAxis2";
            this.TxtXAxis2.Size = new System.Drawing.Size(37, 23);
            this.TxtXAxis2.TabIndex = 18;
            this.TxtXAxis2.Text = "0.0";
            // 
            // LblXAxis2
            // 
            this.LblXAxis2.AutoSize = true;
            this.LblXAxis2.Location = new System.Drawing.Point(1078, 434);
            this.LblXAxis2.Name = "LblXAxis2";
            this.LblXAxis2.Size = new System.Drawing.Size(14, 15);
            this.LblXAxis2.TabIndex = 17;
            this.LblXAxis2.Text = "X";
            // 
            // LblCameraInfo2
            // 
            this.LblCameraInfo2.AutoSize = true;
            this.LblCameraInfo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraInfo2.Location = new System.Drawing.Point(1080, 408);
            this.LblCameraInfo2.Name = "LblCameraInfo2";
            this.LblCameraInfo2.Size = new System.Drawing.Size(113, 15);
            this.LblCameraInfo2.TabIndex = 16;
            this.LblCameraInfo2.Text = "Camera Info 2 - cm";
            // 
            // CbbCalibrations
            // 
            this.CbbCalibrations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbCalibrations.FormattingEnabled = true;
            this.CbbCalibrations.Location = new System.Drawing.Point(12, 306);
            this.CbbCalibrations.Name = "CbbCalibrations";
            this.CbbCalibrations.Size = new System.Drawing.Size(320, 23);
            this.CbbCalibrations.TabIndex = 23;
            this.CbbCalibrations.SelectedIndexChanged += new System.EventHandler(this.CbbCalibrations_SelectedIndexChanged);
            // 
            // LblCalibrations
            // 
            this.LblCalibrations.AutoSize = true;
            this.LblCalibrations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCalibrations.Location = new System.Drawing.Point(12, 288);
            this.LblCalibrations.Name = "LblCalibrations";
            this.LblCalibrations.Size = new System.Drawing.Size(66, 15);
            this.LblCalibrations.TabIndex = 24;
            this.LblCalibrations.Text = "Calibration";
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(1078, 745);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(217, 23);
            this.BtnReset.TabIndex = 25;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // LblCameraMatrix
            // 
            this.LblCameraMatrix.AutoSize = true;
            this.LblCameraMatrix.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraMatrix.Location = new System.Drawing.Point(12, 355);
            this.LblCameraMatrix.Name = "LblCameraMatrix";
            this.LblCameraMatrix.Size = new System.Drawing.Size(89, 15);
            this.LblCameraMatrix.TabIndex = 26;
            this.LblCameraMatrix.Text = "Camera Matrix";
            // 
            // LblCameraMatrixValue
            // 
            this.LblCameraMatrixValue.AutoSize = true;
            this.LblCameraMatrixValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraMatrixValue.Location = new System.Drawing.Point(12, 377);
            this.LblCameraMatrixValue.Name = "LblCameraMatrixValue";
            this.LblCameraMatrixValue.Size = new System.Drawing.Size(37, 15);
            this.LblCameraMatrixValue.TabIndex = 27;
            this.LblCameraMatrixValue.Text = "value";
            // 
            // BtnTriangulate
            // 
            this.BtnTriangulate.Location = new System.Drawing.Point(12, 550);
            this.BtnTriangulate.Name = "BtnTriangulate";
            this.BtnTriangulate.Size = new System.Drawing.Size(215, 23);
            this.BtnTriangulate.TabIndex = 28;
            this.BtnTriangulate.Text = "Triangulate";
            this.BtnTriangulate.UseVisualStyleBackColor = true;
            this.BtnTriangulate.Click += new System.EventHandler(this.BtnTriangulate_Click);
            // 
            // TxtObjectName
            // 
            this.TxtObjectName.Location = new System.Drawing.Point(12, 521);
            this.TxtObjectName.Name = "TxtObjectName";
            this.TxtObjectName.Size = new System.Drawing.Size(215, 23);
            this.TxtObjectName.TabIndex = 29;
            // 
            // LblTriangulationResult
            // 
            this.LblTriangulationResult.AutoSize = true;
            this.LblTriangulationResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTriangulationResult.Location = new System.Drawing.Point(12, 503);
            this.LblTriangulationResult.Name = "LblTriangulationResult";
            this.LblTriangulationResult.Size = new System.Drawing.Size(80, 15);
            this.LblTriangulationResult.TabIndex = 30;
            this.LblTriangulationResult.Text = "Object Name";
            // 
            // StereoImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 819);
            this.Controls.Add(this.LblTriangulationResult);
            this.Controls.Add(this.TxtObjectName);
            this.Controls.Add(this.BtnTriangulate);
            this.Controls.Add(this.LblCameraMatrixValue);
            this.Controls.Add(this.LblCameraMatrix);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.LblCalibrations);
            this.Controls.Add(this.CbbCalibrations);
            this.Controls.Add(this.TxtZAxis2);
            this.Controls.Add(this.LblZAxis2);
            this.Controls.Add(this.TxtYAxis2);
            this.Controls.Add(this.LblYAxis2);
            this.Controls.Add(this.TxtXAxis2);
            this.Controls.Add(this.LblXAxis2);
            this.Controls.Add(this.LblCameraInfo2);
            this.Controls.Add(this.BtnCaptureImage);
            this.Controls.Add(this.PbImage2);
            this.Controls.Add(this.PbImage1);
            this.Controls.Add(this.CbbSourceCamera);
            this.Controls.Add(this.TxtZAxis1);
            this.Controls.Add(this.LblZAxis1);
            this.Controls.Add(this.TxtYAxis1);
            this.Controls.Add(this.LblYAxis1);
            this.Controls.Add(this.TxtXAxis1);
            this.Controls.Add(this.LblXAxis1);
            this.Controls.Add(this.LblCameraInfo1);
            this.Controls.Add(this.LiveCamImage);
            this.Name = "StereoImageForm";
            this.Text = "Camera - Fotogrametria";
            ((System.ComponentModel.ISupportInitialize)(this.LiveCamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    

    #endregion
    private Label LblXAxis1;
    private Label LblYAxis1;
    private Label LblZAxis1;

    private TextBox TxtXAxis1;
    private TextBox TxtYAxis1;
    private TextBox TxtZAxis1;

    private ComboBox CbbSourceCamera;

    private PictureBox LiveCamImage;
    private PictureBox PbImage1;
    private PictureBox PbImage2;
    private Button BtnCaptureImage;
    private Label LblCameraInfo1;
    private TextBox TxtZAxis2;
    private Label LblZAxis2;
    private TextBox TxtYAxis2;
    private Label LblYAxis2;
    private TextBox TxtXAxis2;
    private Label LblXAxis2;
    private Label LblCameraInfo2;
    private ComboBox CbbCalibrations;
    private Label LblCalibrations;
    private Button BtnReset;
    private Label LblCameraMatrix;
    private Label LblCameraMatrixValue;
    private Button BtnTriangulate;
    private TextBox TxtObjectName;
    private Label LblTriangulationResult;
}
