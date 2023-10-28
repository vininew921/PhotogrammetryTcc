namespace Calibrator;

partial class CalibratorForm
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
        PbbLiveCamera = new PictureBox();
        LblLiveCamera = new Label();
        CbbSourceCamera = new ComboBox();
        BtnTakePicture = new Button();
        TxtAppId = new TextBox();
        LblSourceCamera = new Label();
        LblAppId = new Label();
        BtnCalibrate = new Button();
        PbbImage1 = new PictureBox();
        PbbImage2 = new PictureBox();
        PbbImage3 = new PictureBox();
        PbbImage6 = new PictureBox();
        PbbImage5 = new PictureBox();
        PbbImage4 = new PictureBox();
        PbbImage9 = new PictureBox();
        PbbImage8 = new PictureBox();
        PbbImage7 = new PictureBox();
        BtnReset = new Button();
        lblCameraResolution = new Label();
        CbbCameraResolution = new ComboBox();
        LblFocus = new Label();
        TrbFocus = new TrackBar();
        ((System.ComponentModel.ISupportInitialize)PbbLiveCamera).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage6).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage5).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage4).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage9).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage8).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage7).BeginInit();
        ((System.ComponentModel.ISupportInitialize)TrbFocus).BeginInit();
        SuspendLayout();
        // 
        // PbbLiveCamera
        // 
        PbbLiveCamera.Location = new Point(62, 46);
        PbbLiveCamera.Name = "PbbLiveCamera";
        PbbLiveCamera.Size = new Size(320, 180);
        PbbLiveCamera.SizeMode = PictureBoxSizeMode.Zoom;
        PbbLiveCamera.TabIndex = 0;
        PbbLiveCamera.TabStop = false;
        // 
        // LblLiveCamera
        // 
        LblLiveCamera.AutoSize = true;
        LblLiveCamera.Location = new Point(62, 28);
        LblLiveCamera.Name = "LblLiveCamera";
        LblLiveCamera.Size = new Size(72, 15);
        LblLiveCamera.TabIndex = 1;
        LblLiveCamera.Text = "Live Camera";
        // 
        // CbbSourceCamera
        // 
        CbbSourceCamera.FormattingEnabled = true;
        CbbSourceCamera.Location = new Point(62, 258);
        CbbSourceCamera.Name = "CbbSourceCamera";
        CbbSourceCamera.Size = new Size(320, 23);
        CbbSourceCamera.TabIndex = 2;
        CbbSourceCamera.SelectedIndexChanged += CbbSourceCamera_SelectedIndexChanged;
        // 
        // BtnTakePicture
        // 
        BtnTakePicture.Location = new Point(62, 287);
        BtnTakePicture.Name = "BtnTakePicture";
        BtnTakePicture.Size = new Size(320, 23);
        BtnTakePicture.TabIndex = 3;
        BtnTakePicture.Text = "Take Next Picture";
        BtnTakePicture.UseVisualStyleBackColor = true;
        BtnTakePicture.Click += BtnTakePicture_Click;
        // 
        // TxtAppId
        // 
        TxtAppId.Location = new Point(62, 452);
        TxtAppId.Name = "TxtAppId";
        TxtAppId.Size = new Size(320, 23);
        TxtAppId.TabIndex = 4;
        // 
        // LblSourceCamera
        // 
        LblSourceCamera.AutoSize = true;
        LblSourceCamera.Location = new Point(62, 240);
        LblSourceCamera.Name = "LblSourceCamera";
        LblSourceCamera.Size = new Size(48, 15);
        LblSourceCamera.TabIndex = 5;
        LblSourceCamera.Text = "Camera";
        // 
        // LblAppId
        // 
        LblAppId.AutoSize = true;
        LblAppId.Location = new Point(62, 434);
        LblAppId.Name = "LblAppId";
        LblAppId.Size = new Size(43, 15);
        LblAppId.TabIndex = 6;
        LblAppId.Text = "App ID";
        // 
        // BtnCalibrate
        // 
        BtnCalibrate.Location = new Point(62, 481);
        BtnCalibrate.Name = "BtnCalibrate";
        BtnCalibrate.Size = new Size(320, 23);
        BtnCalibrate.TabIndex = 7;
        BtnCalibrate.Text = "Calibrate";
        BtnCalibrate.UseVisualStyleBackColor = true;
        BtnCalibrate.Click += BtnCalibrate_Click;
        // 
        // PbbImage1
        // 
        PbbImage1.Location = new Point(510, 46);
        PbbImage1.Name = "PbbImage1";
        PbbImage1.Size = new Size(320, 180);
        PbbImage1.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage1.TabIndex = 8;
        PbbImage1.TabStop = false;
        // 
        // PbbImage2
        // 
        PbbImage2.Location = new Point(836, 46);
        PbbImage2.Name = "PbbImage2";
        PbbImage2.Size = new Size(320, 180);
        PbbImage2.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage2.TabIndex = 9;
        PbbImage2.TabStop = false;
        // 
        // PbbImage3
        // 
        PbbImage3.Location = new Point(1162, 46);
        PbbImage3.Name = "PbbImage3";
        PbbImage3.Size = new Size(320, 180);
        PbbImage3.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage3.TabIndex = 10;
        PbbImage3.TabStop = false;
        // 
        // PbbImage6
        // 
        PbbImage6.Location = new Point(1162, 232);
        PbbImage6.Name = "PbbImage6";
        PbbImage6.Size = new Size(320, 180);
        PbbImage6.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage6.TabIndex = 13;
        PbbImage6.TabStop = false;
        // 
        // PbbImage5
        // 
        PbbImage5.Location = new Point(836, 232);
        PbbImage5.Name = "PbbImage5";
        PbbImage5.Size = new Size(320, 180);
        PbbImage5.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage5.TabIndex = 12;
        PbbImage5.TabStop = false;
        // 
        // PbbImage4
        // 
        PbbImage4.Location = new Point(510, 232);
        PbbImage4.Name = "PbbImage4";
        PbbImage4.Size = new Size(320, 180);
        PbbImage4.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage4.TabIndex = 11;
        PbbImage4.TabStop = false;
        // 
        // PbbImage9
        // 
        PbbImage9.Location = new Point(1162, 418);
        PbbImage9.Name = "PbbImage9";
        PbbImage9.Size = new Size(320, 180);
        PbbImage9.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage9.TabIndex = 16;
        PbbImage9.TabStop = false;
        // 
        // PbbImage8
        // 
        PbbImage8.Location = new Point(836, 418);
        PbbImage8.Name = "PbbImage8";
        PbbImage8.Size = new Size(320, 180);
        PbbImage8.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage8.TabIndex = 15;
        PbbImage8.TabStop = false;
        // 
        // PbbImage7
        // 
        PbbImage7.Location = new Point(510, 418);
        PbbImage7.Name = "PbbImage7";
        PbbImage7.Size = new Size(320, 180);
        PbbImage7.SizeMode = PictureBoxSizeMode.Zoom;
        PbbImage7.TabIndex = 14;
        PbbImage7.TabStop = false;
        // 
        // BtnReset
        // 
        BtnReset.Location = new Point(62, 575);
        BtnReset.Name = "BtnReset";
        BtnReset.Size = new Size(320, 23);
        BtnReset.TabIndex = 17;
        BtnReset.Text = "Reset";
        BtnReset.UseVisualStyleBackColor = true;
        BtnReset.Click += BtnReset_Click;
        // 
        // lblCameraResolution
        // 
        lblCameraResolution.AutoSize = true;
        lblCameraResolution.Location = new Point(62, 313);
        lblCameraResolution.Name = "lblCameraResolution";
        lblCameraResolution.Size = new Size(107, 15);
        lblCameraResolution.TabIndex = 19;
        lblCameraResolution.Text = "Camera Resolution";
        // 
        // CbbCameraResolution
        // 
        CbbCameraResolution.FormattingEnabled = true;
        CbbCameraResolution.Location = new Point(62, 331);
        CbbCameraResolution.Name = "CbbCameraResolution";
        CbbCameraResolution.Size = new Size(320, 23);
        CbbCameraResolution.TabIndex = 18;
        CbbCameraResolution.SelectedIndexChanged += CbbCameraResolution_SelectedIndexChanged;
        // 
        // LblFocus
        // 
        LblFocus.AutoSize = true;
        LblFocus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        LblFocus.Location = new Point(62, 368);
        LblFocus.Name = "LblFocus";
        LblFocus.Size = new Size(56, 15);
        LblFocus.TabIndex = 44;
        LblFocus.Text = "Focus - 0";
        // 
        // TrbFocus
        // 
        TrbFocus.Location = new Point(59, 386);
        TrbFocus.Maximum = 100;
        TrbFocus.Name = "TrbFocus";
        TrbFocus.Size = new Size(320, 45);
        TrbFocus.TabIndex = 43;
        TrbFocus.Scroll += TrbFocus_Scroll;
        // 
        // CalibratorForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1569, 625);
        Controls.Add(LblFocus);
        Controls.Add(TrbFocus);
        Controls.Add(lblCameraResolution);
        Controls.Add(CbbCameraResolution);
        Controls.Add(BtnReset);
        Controls.Add(PbbImage9);
        Controls.Add(PbbImage8);
        Controls.Add(PbbImage7);
        Controls.Add(PbbImage6);
        Controls.Add(PbbImage5);
        Controls.Add(PbbImage4);
        Controls.Add(PbbImage3);
        Controls.Add(PbbImage2);
        Controls.Add(PbbImage1);
        Controls.Add(BtnCalibrate);
        Controls.Add(LblAppId);
        Controls.Add(LblSourceCamera);
        Controls.Add(TxtAppId);
        Controls.Add(BtnTakePicture);
        Controls.Add(CbbSourceCamera);
        Controls.Add(LblLiveCamera);
        Controls.Add(PbbLiveCamera);
        Name = "CalibratorForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)PbbLiveCamera).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage1).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage2).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage3).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage6).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage5).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage4).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage9).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage8).EndInit();
        ((System.ComponentModel.ISupportInitialize)PbbImage7).EndInit();
        ((System.ComponentModel.ISupportInitialize)TrbFocus).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox PbbLiveCamera;
    private Label LblLiveCamera;
    private ComboBox CbbSourceCamera;
    private Button BtnTakePicture;
    private TextBox TxtAppId;
    private Label LblSourceCamera;
    private Label LblAppId;
    private Button BtnCalibrate;
    private PictureBox PbbImage1;
    private PictureBox PbbImage2;
    private PictureBox PbbImage3;
    private PictureBox PbbImage6;
    private PictureBox PbbImage5;
    private PictureBox PbbImage4;
    private PictureBox PbbImage9;
    private PictureBox PbbImage8;
    private PictureBox PbbImage7;
    private Button BtnReset;
    private Label lblCameraResolution;
    private ComboBox CbbCameraResolution;
    private Label LblFocus;
    private TrackBar TrbFocus;
}
