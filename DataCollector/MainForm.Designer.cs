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
            this.BtnInit = new System.Windows.Forms.Button();
            this.PicCamImage = new System.Windows.Forms.PictureBox();
            this.LblCameraInfo = new System.Windows.Forms.Label();
            this.LblXAxis = new System.Windows.Forms.Label();
            this.TxbXAxis = new System.Windows.Forms.TextBox();
            this.TxbYAxis = new System.Windows.Forms.TextBox();
            this.LblYAxis = new System.Windows.Forms.Label();
            this.TxbZAxis = new System.Windows.Forms.TextBox();
            this.LblZAxis = new System.Windows.Forms.Label();
            this.CbbSourceCamera = new System.Windows.Forms.ComboBox();
            this.PicCroppedImage = new System.Windows.Forms.PictureBox();
            this.BtnDone = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicCamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCroppedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnInit
            // 
            this.BtnInit.Location = new System.Drawing.Point(12, 237);
            this.BtnInit.Name = "BtnInit";
            this.BtnInit.Size = new System.Drawing.Size(150, 23);
            this.BtnInit.TabIndex = 0;
            this.BtnInit.Text = "Iniciar";
            this.BtnInit.UseVisualStyleBackColor = true;
            this.BtnInit.Click += BtnInit_Click;
            // 
            // PicCamImagem
            // 
            this.PicCamImage.Location = new System.Drawing.Point(12, 12);
            this.PicCamImage.Name = "PicCamImagem";
            this.PicCamImage.Size = new System.Drawing.Size(305, 172);
            this.PicCamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicCamImage.TabIndex = 1;
            this.PicCamImage.TabStop = false;
            // 
            // LblCameraInfo
            // 
            this.LblCameraInfo.AutoSize = true;
            this.LblCameraInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCameraInfo.Location = new System.Drawing.Point(15, 288);
            this.LblCameraInfo.Name = "LblCameraInfo";
            this.LblCameraInfo.Size = new System.Drawing.Size(75, 15);
            this.LblCameraInfo.TabIndex = 2;
            this.LblCameraInfo.Text = "Camera Info";
            // 
            // LblXAxis
            // 
            this.LblXAxis.AutoSize = true;
            this.LblXAxis.Location = new System.Drawing.Point(13, 322);
            this.LblXAxis.Name = "LblXAxis";
            this.LblXAxis.Size = new System.Drawing.Size(39, 15);
            this.LblXAxis.TabIndex = 3;
            this.LblXAxis.Text = "Axis X";
            // 
            // TxbXAxis
            // 
            this.TxbXAxis.Location = new System.Drawing.Point(15, 340);
            this.TxbXAxis.Name = "TxbXAxis";
            this.TxbXAxis.Size = new System.Drawing.Size(37, 23);
            this.TxbXAxis.TabIndex = 4;
            this.TxbXAxis.Text = "0.0";
            // 
            // TxbYAxis
            // 
            this.TxbYAxis.Location = new System.Drawing.Point(92, 340);
            this.TxbYAxis.Name = "TxbYAxis";
            this.TxbYAxis.Size = new System.Drawing.Size(37, 23);
            this.TxbYAxis.TabIndex = 6;
            this.TxbYAxis.Text = "0.0";
            // 
            // LblYAxis
            // 
            this.LblYAxis.AutoSize = true;
            this.LblYAxis.Location = new System.Drawing.Point(90, 322);
            this.LblYAxis.Name = "LblYAxis";
            this.LblYAxis.Size = new System.Drawing.Size(39, 15);
            this.LblYAxis.TabIndex = 5;
            this.LblYAxis.Text = "Axis Y";
            // 
            // TxbZAxis
            // 
            this.TxbZAxis.Location = new System.Drawing.Point(159, 340);
            this.TxbZAxis.Name = "TxbZAxis";
            this.TxbZAxis.Size = new System.Drawing.Size(37, 23);
            this.TxbZAxis.TabIndex = 8;
            this.TxbZAxis.Text = "0.0";
            // 
            // LblZAxis
            // 
            this.LblZAxis.AutoSize = true;
            this.LblZAxis.Location = new System.Drawing.Point(157, 322);
            this.LblZAxis.Name = "LblZAxis";
            this.LblZAxis.Size = new System.Drawing.Size(39, 15);
            this.LblZAxis.TabIndex = 7;
            this.LblZAxis.Text = "Axis Z";
            // 
            // sourceCamera
            // 
            this.CbbSourceCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbSourceCamera.FormattingEnabled = true;
            this.CbbSourceCamera.Location = new System.Drawing.Point(12, 208);
            this.CbbSourceCamera.Name = "sourceCamera";
            this.CbbSourceCamera.Size = new System.Drawing.Size(305, 23);
            this.CbbSourceCamera.TabIndex = 10;
            this.CbbSourceCamera.SelectedIndexChanged += SourceCamera_SelectedIndexChanged;
            // 
            // picImagemRecortada
            // 
            this.PicCroppedImage.Location = new System.Drawing.Point(341, 12);
            this.PicCroppedImage.Name = "picImagemRecortada";
            this.PicCroppedImage.Size = new System.Drawing.Size(305, 172);
            this.PicCroppedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicCroppedImage.TabIndex = 11;
            this.PicCroppedImage.TabStop = false;
            // 
            // BtnDone
            // 
            this.BtnDone.Location = new System.Drawing.Point(168, 237);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(149, 23);
            this.BtnDone.TabIndex = 12;
            this.BtnDone.Text = "Encerrar";
            this.BtnDone.UseVisualStyleBackColor = true;
            this.BtnDone.Click += BtnDone_Click;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(497, 208);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(149, 23);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += BtnSave_Click;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDone);
            this.Controls.Add(this.PicCroppedImage);
            this.Controls.Add(this.CbbSourceCamera);
            this.Controls.Add(this.TxbZAxis);
            this.Controls.Add(this.LblZAxis);
            this.Controls.Add(this.TxbYAxis);
            this.Controls.Add(this.LblYAxis);
            this.Controls.Add(this.TxbXAxis);
            this.Controls.Add(this.LblXAxis);
            this.Controls.Add(this.LblCameraInfo);
            this.Controls.Add(this.PicCamImage);
            this.Controls.Add(this.BtnInit);
            this.Name = "MainForm";
            this.Text = "Camera - Fotogrametria";
            ((System.ComponentModel.ISupportInitialize)(this.PicCamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCroppedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    

    #endregion

    private Button BtnInit;
    private Button BtnDone;
    private Button BtnSave;

    private Label LblCameraInfo;
    private Label LblXAxis;
    private Label LblYAxis;
    private Label LblZAxis;

    private TextBox TxbXAxis;
    private TextBox TxbYAxis;
    private TextBox TxbZAxis;

    private ComboBox CbbSourceCamera;

    private PictureBox PicCroppedImage;
    private PictureBox PicCamImage;
}
