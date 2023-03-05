namespace Camera;

partial class Form1
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
        btnInit = new Button();
        picCamImagem = new PictureBox();
        label1 = new Label();
        label2 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        label3 = new Label();
        textBox3 = new TextBox();
        label4 = new Label();
        textBox4 = new TextBox();
        sourceCamera = new ComboBox();
        picImagemRecortada = new PictureBox();
        btnDone = new Button();
        btnSave = new Button();
        ((System.ComponentModel.ISupportInitialize)picCamImagem).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picImagemRecortada).BeginInit();
        SuspendLayout();
        // 
        // btnInit
        // 
        btnInit.Location = new Point(12, 237);
        btnInit.Name = "btnInit";
        btnInit.Size = new Size(150, 23);
        btnInit.TabIndex = 0;
        btnInit.Text = "Iniciar";
        btnInit.UseVisualStyleBackColor = true;
        btnInit.Click += button1_Click;
        // 
        // picCamImagem
        // 
        picCamImagem.Location = new Point(12, 12);
        picCamImagem.Name = "picCamImagem";
        picCamImagem.Size = new Size(305, 172);
        picCamImagem.SizeMode = PictureBoxSizeMode.Zoom;
        picCamImagem.TabIndex = 1;
        picCamImagem.TabStop = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label1.Location = new Point(15, 288);
        label1.Name = "label1";
        label1.Size = new Size(75, 15);
        label1.TabIndex = 2;
        label1.Text = "Camera Info";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(13, 322);
        label2.Name = "label2";
        label2.Size = new Size(39, 15);
        label2.TabIndex = 3;
        label2.Text = "Axis X";
        label2.Click += label2_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(15, 340);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(37, 23);
        textBox1.TabIndex = 4;
        textBox1.Text = "0.0";
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(92, 340);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(37, 23);
        textBox2.TabIndex = 6;
        textBox2.Text = "0.0";
        textBox2.TextChanged += textBox2_TextChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(90, 322);
        label3.Name = "label3";
        label3.Size = new Size(39, 15);
        label3.TabIndex = 5;
        label3.Text = "Axis Y";
        label3.Click += label3_Click;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(159, 340);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(37, 23);
        textBox3.TabIndex = 8;
        textBox3.Text = "0.0";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(157, 322);
        label4.Name = "label4";
        label4.Size = new Size(39, 15);
        label4.TabIndex = 7;
        label4.Text = "Axis Z";
        // 
        // textBox4
        // 
        textBox4.Location = new Point(497, 340);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(181, 23);
        textBox4.TabIndex = 9;
        // 
        // sourceCamera
        // 
        sourceCamera.DropDownStyle = ComboBoxStyle.DropDownList;
        sourceCamera.FormattingEnabled = true;
        sourceCamera.Location = new Point(12, 208);
        sourceCamera.Name = "sourceCamera";
        sourceCamera.Size = new Size(305, 23);
        sourceCamera.TabIndex = 10;
        sourceCamera.SelectedIndexChanged += sourceCamera_SelectedIndexChanged;
        // 
        // picImagemRecortada
        // 
        picImagemRecortada.Location = new Point(341, 12);
        picImagemRecortada.Name = "picImagemRecortada";
        picImagemRecortada.Size = new Size(305, 172);
        picImagemRecortada.SizeMode = PictureBoxSizeMode.Zoom;
        picImagemRecortada.TabIndex = 11;
        picImagemRecortada.TabStop = false;
        // 
        // btnDone
        // 
        btnDone.Location = new Point(168, 237);
        btnDone.Name = "btnDone";
        btnDone.Size = new Size(149, 23);
        btnDone.TabIndex = 12;
        btnDone.Text = "Encerrar";
        btnDone.UseVisualStyleBackColor = true;
        btnDone.Click += btnDone_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(497, 208);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(149, 23);
        btnSave.TabIndex = 13;
        btnSave.Text = "Salvar";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnSave);
        Controls.Add(btnDone);
        Controls.Add(picImagemRecortada);
        Controls.Add(sourceCamera);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(label4);
        Controls.Add(textBox2);
        Controls.Add(label3);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(picCamImagem);
        Controls.Add(btnInit);
        Name = "Form1";
        Text = "Camera - Fotogrametria";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)picCamImagem).EndInit();
        ((System.ComponentModel.ISupportInitialize)picImagemRecortada).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    

    #endregion

    private Button btnInit;
    private PictureBox picCamImagem;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label3;
    private TextBox textBox3;
    private Label label4;
    private TextBox textBox4;
    private ComboBox sourceCamera;
    private PictureBox picImagemRecortada;
    private Button btnDone;
    private Button btnSave;
}
