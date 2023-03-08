using AForge.Video;
using AForge.Video.DirectShow;

namespace Camera;

public partial class MainForm : Form
{
    private readonly FilterInfoCollection _filterInfoCollection;
    private VideoCaptureDevice? _videoCaptureDevice;

    public MainForm()
    {
        InitializeComponent();

        _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        foreach (FilterInfo filterInfo in _filterInfoCollection)
        {
            CbbSourceCamera.Items.Add(filterInfo.Name);
        }

        CbbSourceCamera.SelectedIndex = 0;

        if (!Directory.Exists("./Images"))
        {
            Directory.CreateDirectory("./Images");
        }
    }

    private void BtnInit_Click(object sender, EventArgs e) => InitVideo();

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e) => SetCamImage((Bitmap)e.Frame.Clone());

    private void BtnSave_Click(object sender, EventArgs e)
    {
        SetCroppedImage((Bitmap)PicCamImage.Image.Clone());

        PicCroppedImage.Image.Save($"./Images/{DateTime.Now.Ticks}.png", System.Drawing.Imaging.ImageFormat.Png);
    }

    private void SetCamImage(Bitmap newImageBitmap)
    {
        if (PicCamImage.Image != null)
        {
            PicCamImage.Image.Dispose();
        }

        PicCamImage.Image = newImageBitmap;
    }

    private void SetCroppedImage(Bitmap newImageBitmap)
    {
        if (PicCroppedImage.Image != null)
        {
            PicCroppedImage.Image.Dispose();
        }

        PicCroppedImage.Image = newImageBitmap;
    }

    private void BtnDone_Click(object sender, EventArgs e) => Done();

    private void Done()
    {
        if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
        {
            _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.SignalToStop();
            _videoCaptureDevice = null;
        }
    }

    private void InitVideo()
    {
        if (_videoCaptureDevice == null)
        {
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[CbbSourceCamera.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities[0];
            _videoCaptureDevice.Start();
        }
    }

    private void SourceCamera_SelectedIndexChanged(object sender, EventArgs e)
    {
        Done();
        InitVideo();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        Done();
    }
}
