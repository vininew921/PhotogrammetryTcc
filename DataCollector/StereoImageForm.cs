using AForge.Video;
using AForge.Video.DirectShow;
using PhotogrammetryMath;

namespace StereoImage;

public partial class StereoImageForm : Form
{
    private VideoCaptureDevice? _videoCaptureDevice;

    private readonly FilterInfoCollection _filterInfoCollection;
    private readonly Guid _imageGuid;

    public StereoImageForm()
    {
        InitializeComponent();

        _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        foreach (FilterInfo filterInfo in _filterInfoCollection)
        {
            CbbSourceCamera.Items.Add(filterInfo.Name);
        }

        CbbCalibrations.Items.AddRange(Calibration.GetAvailableCalibrations().ToArray());

        CbbSourceCamera.SelectedIndex = 0;
        CbbCalibrations.SelectedIndex = 0;

        if (!Directory.Exists("./Images"))
        {
            Directory.CreateDirectory("./Images");
        }

        _imageGuid = Guid.NewGuid();
    }

    private void BtnCaptureImage_Click(object sender, EventArgs e) => SetStaticImages((Bitmap)LiveCamImage.Image.Clone());

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e) => SetLiveCamImage((Bitmap)e.Frame.Clone());

    private void SetLiveCamImage(Bitmap newImageBitmap)
    {
        if (LiveCamImage.Image != null)
        {
            LiveCamImage.Image.Dispose();
        }

        LiveCamImage.Image = newImageBitmap;
    }

    private void SetStaticImages(Image image)
    {
        if (PbImage1.Image == null)
        {
            PbImage1.Image = (Bitmap)image.Clone();
            PbImage1.Image.Save($"./Images/{_imageGuid}-1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        else if (PbImage2.Image == null)
        {
            PbImage2.Image = (Bitmap)image.Clone();
            PbImage2.Image.Save($"./Images/{_imageGuid}-2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }

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
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities.First(x => x.FrameSize.Width == 1920 && x.FrameSize.Height == 1080);
            _videoCaptureDevice.Start();
        }
    }

    private void CbbSourceCamera_SelectedIndexChanged(object sender, EventArgs e)
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
