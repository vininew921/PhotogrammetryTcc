using AForge.Video;
using AForge.Video.DirectShow;
using PhotogrammetryMath;

namespace StereoImage;

public partial class StereoImageForm : Form
{
    private int _imageIndex = 0;
    private VideoCaptureDevice? _videoCaptureDevice;

    private readonly FilterInfoCollection _filterInfoCollection;
    private readonly PictureBox[] _pictures;
    private readonly int _maxImages = 2;

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

        _imageIndex = 0;
        _pictures = new PictureBox[2]
        {
            PbImage1,
            PbImage2
        };
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

    private void SetStaticImages(Bitmap image)
    {
        if (_imageIndex < _maxImages)
        {
            _pictures[_imageIndex].Image = (Bitmap)image.Clone();
            _imageIndex++;
        }

        image.Dispose();
    }

    private void Reset()
    {
        _imageIndex = 0;
        for (int i = 0; i < _maxImages; i++)
        {
            if (_pictures[i].Image == null)
            {
                continue;
            }

            _pictures[i].Image.Dispose();
            _pictures[i].Image = null;
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

    private void BtnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
}
