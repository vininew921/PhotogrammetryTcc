using AForge.Video;
using AForge.Video.DirectShow;
using Photogrammetry;
using Shared;
using System.Drawing.Imaging;

namespace Calibrator;

public partial class CalibratorForm : Form
{
    private VideoCaptureDevice? _videoCaptureDevice = default!;
    private List<FilterInfo> _filterInfoCollection = default!;
    private PictureBox[] _calibrationImages = default!;
    private int _calibrationImageIndex = 0;
    private readonly int _maxImages = 9;

    public CalibratorForm()
    {
        InitializeComponent();
        DirectoryManager.SetupDirectories();
        InitializeProperties();
        InitializeComboBoxes();
    }

    private void InitializeComboBoxes()
    {
        _filterInfoCollection = new List<FilterInfo>();
        FilterInfoCollection fiCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        foreach (FilterInfo filterInfo in fiCollection)
        {
            if (new VideoCaptureDevice(filterInfo.MonikerString).VideoCapabilities.Length > 0)
            {
                _filterInfoCollection.Add(filterInfo);
                CbbSourceCamera.Items.Add(filterInfo.Name);
            }
        }

        CbbSourceCamera.SelectedIndex = 0;
        CbbCameraResolution.SelectedIndex = 0;
    }

    private void InitializeProperties()
    {
        _calibrationImageIndex = 0;
        _calibrationImages = new PictureBox[9]
        {
            PbbImage1,
            PbbImage2,
            PbbImage3,
            PbbImage4,
            PbbImage5,
            PbbImage6,
            PbbImage7,
            PbbImage8,
            PbbImage9,
        };
    }

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e) => SetLiveCamImage((Bitmap)e.Frame.Clone());

    private void SetLiveCamImage(Bitmap newImageBitmap)
    {
        PbbLiveCamera.Image?.Dispose();

        PbbLiveCamera.Image = newImageBitmap;
    }

    private void SetStaticImage(Bitmap image)
    {
        _calibrationImages[_calibrationImageIndex].Image = image;
        image.Save($"{DirectoryManager.TemporaryImages}/{Guid.NewGuid()}.png", ImageFormat.Png);
        _calibrationImageIndex++;
    }

    private void InitVideo()
    {
        if (_videoCaptureDevice == null)
        {
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[CbbSourceCamera.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities[CbbCameraResolution.SelectedIndex == -1 ? 0 : CbbCameraResolution.SelectedIndex];

            _videoCaptureDevice.Start();
        }
    }

    private void ResetVideo()
    {
        if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
        {
            _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.SignalToStop();
            _videoCaptureDevice.WaitForStop();
            _videoCaptureDevice = null;
        }
    }

    private void Reset()
    {
        for (int i = 0; i < _calibrationImages.Length; i++)
        {
            _calibrationImages[i].Image?.Dispose();
            _calibrationImages[i].Image = null;
        }

        _calibrationImageIndex = 0;

        foreach (string file in Directory.GetFiles(DirectoryManager.TemporaryImages))
        {
            File.Delete(file);
        }
    }

    private void CbbSourceCamera_SelectedIndexChanged(object sender, EventArgs e)
    {
        Reset();
        ResetVideo();
        InitVideo();

        CbbCameraResolution.Items.Clear();
        CbbCameraResolution.Items.AddRange(
            _videoCaptureDevice!.VideoCapabilities.Select(x =>
                $"{x.FrameSize.Width}x{x.FrameSize.Height} - {x.MaximumFrameRate}fps {x.BitCount}bpp")
            .ToArray());
    }

    private void CbbCameraResolution_SelectedIndexChanged(object sender, EventArgs e)
    {
        Reset();
        ResetVideo();
        InitVideo();
    }

    private void BtnReset_Click(object sender, EventArgs e) => Reset();

    private void BtnTakePicture_Click(object sender, EventArgs e)
    {
        if (_calibrationImageIndex == _maxImages)
        {
            return;
        }

        SetStaticImage((Bitmap)PbbLiveCamera.Image.Clone());
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        ResetVideo();
    }

    private void BtnCalibrate_Click(object sender, EventArgs e)
    {
        if (_calibrationImageIndex < 9)
        {
            return;
        }

        Calibration.Calibrate(TxtAppId.Text);

        MessageBox.Show("Calibration Successful");
    }
}
