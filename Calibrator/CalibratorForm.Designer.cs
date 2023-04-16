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
            this.PbbLiveCamera = new System.Windows.Forms.PictureBox();
            this.LblLiveCamera = new System.Windows.Forms.Label();
            this.CbbSourceCamera = new System.Windows.Forms.ComboBox();
            this.BtnTakePicture = new System.Windows.Forms.Button();
            this.TxtAppId = new System.Windows.Forms.TextBox();
            this.LblSourceCamera = new System.Windows.Forms.Label();
            this.LblAppId = new System.Windows.Forms.Label();
            this.BtnCalibrate = new System.Windows.Forms.Button();
            this.PbbImage1 = new System.Windows.Forms.PictureBox();
            this.PbbImage2 = new System.Windows.Forms.PictureBox();
            this.PbbImage3 = new System.Windows.Forms.PictureBox();
            this.PbbImage6 = new System.Windows.Forms.PictureBox();
            this.PbbImage5 = new System.Windows.Forms.PictureBox();
            this.PbbImage4 = new System.Windows.Forms.PictureBox();
            this.PbbImage9 = new System.Windows.Forms.PictureBox();
            this.PbbImage8 = new System.Windows.Forms.PictureBox();
            this.PbbImage7 = new System.Windows.Forms.PictureBox();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbbLiveCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage7)).BeginInit();
            this.SuspendLayout();
            // 
            // PbbLiveCamera
            // 
            this.PbbLiveCamera.Location = new System.Drawing.Point(62, 46);
            this.PbbLiveCamera.Name = "PbbLiveCamera";
            this.PbbLiveCamera.Size = new System.Drawing.Size(320, 180);
            this.PbbLiveCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbLiveCamera.TabIndex = 0;
            this.PbbLiveCamera.TabStop = false;
            // 
            // LblLiveCamera
            // 
            this.LblLiveCamera.AutoSize = true;
            this.LblLiveCamera.Location = new System.Drawing.Point(62, 28);
            this.LblLiveCamera.Name = "LblLiveCamera";
            this.LblLiveCamera.Size = new System.Drawing.Size(72, 15);
            this.LblLiveCamera.TabIndex = 1;
            this.LblLiveCamera.Text = "Live Camera";
            // 
            // CbbSourceCamera
            // 
            this.CbbSourceCamera.FormattingEnabled = true;
            this.CbbSourceCamera.Location = new System.Drawing.Point(62, 258);
            this.CbbSourceCamera.Name = "CbbSourceCamera";
            this.CbbSourceCamera.Size = new System.Drawing.Size(320, 23);
            this.CbbSourceCamera.TabIndex = 2;
            this.CbbSourceCamera.SelectedIndexChanged += new System.EventHandler(this.CbbSourceCamera_SelectedIndexChanged);
            // 
            // BtnTakePicture
            // 
            this.BtnTakePicture.Location = new System.Drawing.Point(62, 287);
            this.BtnTakePicture.Name = "BtnTakePicture";
            this.BtnTakePicture.Size = new System.Drawing.Size(320, 23);
            this.BtnTakePicture.TabIndex = 3;
            this.BtnTakePicture.Text = "Take Next Picture";
            this.BtnTakePicture.UseVisualStyleBackColor = true;
            this.BtnTakePicture.Click += new System.EventHandler(this.BtnTakePicture_Click);
            // 
            // TxtAppId
            // 
            this.TxtAppId.Location = new System.Drawing.Point(62, 362);
            this.TxtAppId.Name = "TxtAppId";
            this.TxtAppId.Size = new System.Drawing.Size(320, 23);
            this.TxtAppId.TabIndex = 4;
            // 
            // LblSourceCamera
            // 
            this.LblSourceCamera.AutoSize = true;
            this.LblSourceCamera.Location = new System.Drawing.Point(62, 240);
            this.LblSourceCamera.Name = "LblSourceCamera";
            this.LblSourceCamera.Size = new System.Drawing.Size(48, 15);
            this.LblSourceCamera.TabIndex = 5;
            this.LblSourceCamera.Text = "Camera";
            // 
            // LblAppId
            // 
            this.LblAppId.AutoSize = true;
            this.LblAppId.Location = new System.Drawing.Point(62, 344);
            this.LblAppId.Name = "LblAppId";
            this.LblAppId.Size = new System.Drawing.Size(43, 15);
            this.LblAppId.TabIndex = 6;
            this.LblAppId.Text = "App ID";
            // 
            // BtnCalibrate
            // 
            this.BtnCalibrate.Location = new System.Drawing.Point(62, 391);
            this.BtnCalibrate.Name = "BtnCalibrate";
            this.BtnCalibrate.Size = new System.Drawing.Size(320, 23);
            this.BtnCalibrate.TabIndex = 7;
            this.BtnCalibrate.Text = "Calibrate";
            this.BtnCalibrate.UseVisualStyleBackColor = true;
            this.BtnCalibrate.Click += new System.EventHandler(this.BtnCalibrate_Click);
            // 
            // PbbImage1
            // 
            this.PbbImage1.Location = new System.Drawing.Point(510, 46);
            this.PbbImage1.Name = "PbbImage1";
            this.PbbImage1.Size = new System.Drawing.Size(320, 180);
            this.PbbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage1.TabIndex = 8;
            this.PbbImage1.TabStop = false;
            // 
            // PbbImage2
            // 
            this.PbbImage2.Location = new System.Drawing.Point(836, 46);
            this.PbbImage2.Name = "PbbImage2";
            this.PbbImage2.Size = new System.Drawing.Size(320, 180);
            this.PbbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage2.TabIndex = 9;
            this.PbbImage2.TabStop = false;
            // 
            // PbbImage3
            // 
            this.PbbImage3.Location = new System.Drawing.Point(1162, 46);
            this.PbbImage3.Name = "PbbImage3";
            this.PbbImage3.Size = new System.Drawing.Size(320, 180);
            this.PbbImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage3.TabIndex = 10;
            this.PbbImage3.TabStop = false;
            // 
            // PbbImage6
            // 
            this.PbbImage6.Location = new System.Drawing.Point(1162, 232);
            this.PbbImage6.Name = "PbbImage6";
            this.PbbImage6.Size = new System.Drawing.Size(320, 180);
            this.PbbImage6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage6.TabIndex = 13;
            this.PbbImage6.TabStop = false;
            // 
            // PbbImage5
            // 
            this.PbbImage5.Location = new System.Drawing.Point(836, 232);
            this.PbbImage5.Name = "PbbImage5";
            this.PbbImage5.Size = new System.Drawing.Size(320, 180);
            this.PbbImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage5.TabIndex = 12;
            this.PbbImage5.TabStop = false;
            // 
            // PbbImage4
            // 
            this.PbbImage4.Location = new System.Drawing.Point(510, 232);
            this.PbbImage4.Name = "PbbImage4";
            this.PbbImage4.Size = new System.Drawing.Size(320, 180);
            this.PbbImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage4.TabIndex = 11;
            this.PbbImage4.TabStop = false;
            // 
            // PbbImage9
            // 
            this.PbbImage9.Location = new System.Drawing.Point(1162, 418);
            this.PbbImage9.Name = "PbbImage9";
            this.PbbImage9.Size = new System.Drawing.Size(320, 180);
            this.PbbImage9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage9.TabIndex = 16;
            this.PbbImage9.TabStop = false;
            // 
            // PbbImage8
            // 
            this.PbbImage8.Location = new System.Drawing.Point(836, 418);
            this.PbbImage8.Name = "PbbImage8";
            this.PbbImage8.Size = new System.Drawing.Size(320, 180);
            this.PbbImage8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage8.TabIndex = 15;
            this.PbbImage8.TabStop = false;
            // 
            // PbbImage7
            // 
            this.PbbImage7.Location = new System.Drawing.Point(510, 418);
            this.PbbImage7.Name = "PbbImage7";
            this.PbbImage7.Size = new System.Drawing.Size(320, 180);
            this.PbbImage7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbbImage7.TabIndex = 14;
            this.PbbImage7.TabStop = false;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(62, 575);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(320, 23);
            this.BtnReset.TabIndex = 17;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // CalibratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 625);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.PbbImage9);
            this.Controls.Add(this.PbbImage8);
            this.Controls.Add(this.PbbImage7);
            this.Controls.Add(this.PbbImage6);
            this.Controls.Add(this.PbbImage5);
            this.Controls.Add(this.PbbImage4);
            this.Controls.Add(this.PbbImage3);
            this.Controls.Add(this.PbbImage2);
            this.Controls.Add(this.PbbImage1);
            this.Controls.Add(this.BtnCalibrate);
            this.Controls.Add(this.LblAppId);
            this.Controls.Add(this.LblSourceCamera);
            this.Controls.Add(this.TxtAppId);
            this.Controls.Add(this.BtnTakePicture);
            this.Controls.Add(this.CbbSourceCamera);
            this.Controls.Add(this.LblLiveCamera);
            this.Controls.Add(this.PbbLiveCamera);
            this.Name = "CalibratorForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PbbLiveCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbbImage7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
}
