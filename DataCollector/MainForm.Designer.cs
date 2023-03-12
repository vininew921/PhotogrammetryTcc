namespace Camera;

partial class MainForm
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
            this.BtnProcessImages = new System.Windows.Forms.Button();
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
            this.TxtFocalDistance = new System.Windows.Forms.TextBox();
            this.LblFocalDistance = new System.Windows.Forms.Label();
            this.CbbLengthType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.LiveCamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage2)).BeginInit();
            this.SuspendLayout();
            // 
            // LiveCamImage
            // 
            this.LiveCamImage.Location = new System.Drawing.Point(12, 32);
            this.LiveCamImage.Name = "LiveCamImage";
            this.LiveCamImage.Size = new System.Drawing.Size(305, 172);
            this.LiveCamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LiveCamImage.TabIndex = 1;
            this.LiveCamImage.TabStop = false;
            // 
            // LblXAxis1
            // 
            this.LblXAxis1.AutoSize = true;
            this.LblXAxis1.Location = new System.Drawing.Point(874, 58);
            this.LblXAxis1.Name = "LblXAxis1";
            this.LblXAxis1.Size = new System.Drawing.Size(14, 15);
            this.LblXAxis1.TabIndex = 3;
            this.LblXAxis1.Text = "X";
            // 
            // TxtXAxis1
            // 
            this.TxtXAxis1.Location = new System.Drawing.Point(876, 76);
            this.TxtXAxis1.Name = "TxtXAxis1";
            this.TxtXAxis1.Size = new System.Drawing.Size(37, 23);
            this.TxtXAxis1.TabIndex = 4;
            this.TxtXAxis1.Text = "0.0";
            // 
            // TxtYAxis1
            // 
            this.TxtYAxis1.Location = new System.Drawing.Point(923, 76);
            this.TxtYAxis1.Name = "TxtYAxis1";
            this.TxtYAxis1.Size = new System.Drawing.Size(37, 23);
            this.TxtYAxis1.TabIndex = 6;
            this.TxtYAxis1.Text = "0.0";
            // 
            // LblYAxis1
            // 
            this.LblYAxis1.AutoSize = true;
            this.LblYAxis1.Location = new System.Drawing.Point(923, 58);
            this.LblYAxis1.Name = "LblYAxis1";
            this.LblYAxis1.Size = new System.Drawing.Size(14, 15);
            this.LblYAxis1.TabIndex = 5;
            this.LblYAxis1.Text = "Y";
            // 
            // TxtZAxis1
            // 
            this.TxtZAxis1.Location = new System.Drawing.Point(966, 76);
            this.TxtZAxis1.Name = "TxtZAxis1";
            this.TxtZAxis1.Size = new System.Drawing.Size(37, 23);
            this.TxtZAxis1.TabIndex = 8;
            this.TxtZAxis1.Text = "0.0";
            // 
            // LblZAxis1
            // 
            this.LblZAxis1.AutoSize = true;
            this.LblZAxis1.Location = new System.Drawing.Point(968, 58);
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
            this.CbbSourceCamera.Size = new System.Drawing.Size(305, 23);
            this.CbbSourceCamera.TabIndex = 10;
            this.CbbSourceCamera.SelectedIndexChanged += SourceCamera_SelectedIndexChanged;
            // 
            // PbImage1
            // 
            this.PbImage1.Location = new System.Drawing.Point(551, 32);
            this.PbImage1.Name = "PbImage1";
            this.PbImage1.Size = new System.Drawing.Size(305, 172);
            this.PbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbImage1.TabIndex = 11;
            this.PbImage1.TabStop = false;
            // 
            // BtnProcessImages
            // 
            this.BtnProcessImages.Location = new System.Drawing.Point(551, 457);
            this.BtnProcessImages.Name = "BtnProcessImages";
            this.BtnProcessImages.Size = new System.Drawing.Size(305, 23);
            this.BtnProcessImages.TabIndex = 13;
            this.BtnProcessImages.Text = "Processar Imagens";
            this.BtnProcessImages.UseVisualStyleBackColor = true;
            this.BtnProcessImages.Click += new System.EventHandler(this.BtnProcessImages_Click);
            // 
            // PbImage2
            // 
            this.PbImage2.Location = new System.Drawing.Point(551, 220);
            this.PbImage2.Name = "PbImage2";
            this.PbImage2.Size = new System.Drawing.Size(305, 172);
            this.PbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbImage2.TabIndex = 14;
            this.PbImage2.TabStop = false;
            // 
            // BtnCaptureImage
            // 
            this.BtnCaptureImage.Location = new System.Drawing.Point(12, 249);
            this.BtnCaptureImage.Name = "BtnCaptureImage";
            this.BtnCaptureImage.Size = new System.Drawing.Size(305, 23);
            this.BtnCaptureImage.TabIndex = 15;
            this.BtnCaptureImage.Text = "Capturar Imagem";
            this.BtnCaptureImage.UseVisualStyleBackColor = true;
            this.BtnCaptureImage.Click += new System.EventHandler(this.BtnCaptureImage_Click);
            // 
            // LblCameraInfo1
            // 
            this.LblCameraInfo1.AutoSize = true;
            this.LblCameraInfo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraInfo1.Location = new System.Drawing.Point(876, 32);
            this.LblCameraInfo1.Name = "LblCameraInfo1";
            this.LblCameraInfo1.Size = new System.Drawing.Size(113, 15);
            this.LblCameraInfo1.TabIndex = 2;
            this.LblCameraInfo1.Text = "Camera Info 1 - cm";
            // 
            // TxtZAxis2
            // 
            this.TxtZAxis2.Location = new System.Drawing.Point(966, 264);
            this.TxtZAxis2.Name = "TxtZAxis2";
            this.TxtZAxis2.Size = new System.Drawing.Size(37, 23);
            this.TxtZAxis2.TabIndex = 22;
            this.TxtZAxis2.Text = "0.0";
            // 
            // LblZAxis2
            // 
            this.LblZAxis2.AutoSize = true;
            this.LblZAxis2.Location = new System.Drawing.Point(968, 246);
            this.LblZAxis2.Name = "LblZAxis2";
            this.LblZAxis2.Size = new System.Drawing.Size(14, 15);
            this.LblZAxis2.TabIndex = 21;
            this.LblZAxis2.Text = "Z";
            // 
            // TxtYAxis2
            // 
            this.TxtYAxis2.Location = new System.Drawing.Point(923, 264);
            this.TxtYAxis2.Name = "TxtYAxis2";
            this.TxtYAxis2.Size = new System.Drawing.Size(37, 23);
            this.TxtYAxis2.TabIndex = 20;
            this.TxtYAxis2.Text = "0.0";
            // 
            // LblYAxis2
            // 
            this.LblYAxis2.AutoSize = true;
            this.LblYAxis2.Location = new System.Drawing.Point(923, 246);
            this.LblYAxis2.Name = "LblYAxis2";
            this.LblYAxis2.Size = new System.Drawing.Size(14, 15);
            this.LblYAxis2.TabIndex = 19;
            this.LblYAxis2.Text = "Y";
            // 
            // TxtXAxis2
            // 
            this.TxtXAxis2.Location = new System.Drawing.Point(876, 264);
            this.TxtXAxis2.Name = "TxtXAxis2";
            this.TxtXAxis2.Size = new System.Drawing.Size(37, 23);
            this.TxtXAxis2.TabIndex = 18;
            this.TxtXAxis2.Text = "0.0";
            // 
            // LblXAxis2
            // 
            this.LblXAxis2.AutoSize = true;
            this.LblXAxis2.Location = new System.Drawing.Point(874, 246);
            this.LblXAxis2.Name = "LblXAxis2";
            this.LblXAxis2.Size = new System.Drawing.Size(14, 15);
            this.LblXAxis2.TabIndex = 17;
            this.LblXAxis2.Text = "X";
            // 
            // LblCameraInfo2
            // 
            this.LblCameraInfo2.AutoSize = true;
            this.LblCameraInfo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraInfo2.Location = new System.Drawing.Point(876, 220);
            this.LblCameraInfo2.Name = "LblCameraInfo2";
            this.LblCameraInfo2.Size = new System.Drawing.Size(113, 15);
            this.LblCameraInfo2.TabIndex = 16;
            this.LblCameraInfo2.Text = "Camera Info 2 - cm";
            // 
            // TxtFocalDistance
            // 
            this.TxtFocalDistance.Location = new System.Drawing.Point(551, 418);
            this.TxtFocalDistance.Name = "TxtFocalDistance";
            this.TxtFocalDistance.Size = new System.Drawing.Size(111, 23);
            this.TxtFocalDistance.TabIndex = 23;
            this.TxtFocalDistance.Text = "0.0";
            // 
            // LblFocalDistance
            // 
            this.LblFocalDistance.AutoSize = true;
            this.LblFocalDistance.Location = new System.Drawing.Point(551, 400);
            this.LblFocalDistance.Name = "LblFocalDistance";
            this.LblFocalDistance.Size = new System.Drawing.Size(86, 15);
            this.LblFocalDistance.TabIndex = 24;
            this.LblFocalDistance.Text = "Distância Focal";
            // 
            // CbbLengthType
            // 
            this.CbbLengthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbLengthType.FormattingEnabled = true;
            this.CbbLengthType.Location = new System.Drawing.Point(668, 418);
            this.CbbLengthType.Name = "CbbLengthType";
            this.CbbLengthType.Size = new System.Drawing.Size(137, 23);
            this.CbbLengthType.TabIndex = 25;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 519);
            this.Controls.Add(this.CbbLengthType);
            this.Controls.Add(this.LblFocalDistance);
            this.Controls.Add(this.TxtFocalDistance);
            this.Controls.Add(this.TxtZAxis2);
            this.Controls.Add(this.LblZAxis2);
            this.Controls.Add(this.TxtYAxis2);
            this.Controls.Add(this.LblYAxis2);
            this.Controls.Add(this.TxtXAxis2);
            this.Controls.Add(this.LblXAxis2);
            this.Controls.Add(this.LblCameraInfo2);
            this.Controls.Add(this.BtnCaptureImage);
            this.Controls.Add(this.PbImage2);
            this.Controls.Add(this.BtnProcessImages);
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
            this.Name = "MainForm";
            this.Text = "Camera - Fotogrametria";
            ((System.ComponentModel.ISupportInitialize)(this.LiveCamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    

    #endregion
    private Button BtnProcessImages;
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
    private TextBox TxtFocalDistance;
    private Label LblFocalDistance;
    private ComboBox CbbLengthType;
}
