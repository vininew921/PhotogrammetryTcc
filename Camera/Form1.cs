using AForge.Video;
using AForge.Video.DirectShow;
using System.Net.Http.Headers;

namespace Camera;

public partial class Form1 : Form
{

    FilterInfoCollection _filterInfoCollection;
    VideoCaptureDevice _videoCaptureDevice;

    public Form1()
    {
        InitializeComponent();

        _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        foreach (FilterInfo filterInfo in _filterInfoCollection)
        {
            sourceCamera.Items.Add(filterInfo.Name);
        }

        sourceCamera.SelectedIndex = 0;
        _videoCaptureDevice = new VideoCaptureDevice();

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
        InitVideo();
    }

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e)
    {
        picCamImagem.Image = (Bitmap)e.Frame.Clone();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        Clipboard.Clear();
        Clipboard.SetImage(picCamImagem.Image);
        picImagemRecortada.Image = Clipboard.GetImage();
        Clipboard.Clear();

        picImagemRecortada.Image.Save(@"C:\teste\imagem.png", System.Drawing.Imaging.ImageFormat.Png);


    }

    private void btnDone_Click(object sender, EventArgs e)
    {
        Done();
    }


    private void Done()
    {
        if (!(_videoCaptureDevice == null))
            if (_videoCaptureDevice.IsRunning)
            {
                _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                _videoCaptureDevice.SignalToStop();
                _videoCaptureDevice = null;
            }
    }

    private void InitVideo()
    {
        _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[sourceCamera.SelectedIndex].MonikerString);
        _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
        _videoCaptureDevice.Start();
    }

    private void sourceCamera_SelectedIndexChanged(object sender, EventArgs e) {
        Done();
        InitVideo();
    }

}
