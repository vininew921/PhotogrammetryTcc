using AForge.Video;
using AForge.Video.DirectShow;
using PhotogrammetryMath;
using PhotogrammetryMath.Models;
using System.Drawing.Imaging;

namespace Calibrator;

public partial class CalibratorForm : Form
{
    private VideoCaptureDevice? _videoCaptureDevice = default!;
    private FilterInfoCollection _filterInfoCollection = default!;
    private PictureBox[] _calibrationImages = default!;
    private int _calibrationImageIndex = 0;
    private readonly int _maxImages = 9;

    private static readonly string _tempPath = Path.GetFullPath("./Temp");
    private static readonly string _appData = Path.GetFullPath($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/PhotogrammetryTCC");
    private static readonly string _calibrationResults = Path.GetFullPath($"{_appData}/CalibrationResults");

    public CalibratorForm()
    {
        InitializeComponent();
        InitializeDirectories();
        InitializeProperties();
        InitializeComboBoxes();
    }

    private void InitializeComboBoxes()
    {
        _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        foreach (FilterInfo filterInfo in _filterInfoCollection)
        {
            CbbSourceCamera.Items.Add(filterInfo.Name);
        }

        CbbSourceCamera.SelectedIndex = 0;
    }

    private static void InitializeDirectories()
    {
        string[] dirs = new string[] { _tempPath, _appData, _calibrationResults };

        foreach (string dir in dirs)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
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
        if (PbbLiveCamera.Image != null)
        {
            PbbLiveCamera.Image.Dispose();
        }

        PbbLiveCamera.Image = newImageBitmap;
    }

    private void SetStaticImage(Bitmap image)
    {
        _calibrationImages[_calibrationImageIndex].Image = image;
        image.Save($"{_tempPath}/{Guid.NewGuid()}.png", ImageFormat.Png);
        _calibrationImageIndex++;
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

    private void ResetVideo()
    {
        if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
        {
            _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.SignalToStop();
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

        foreach (string file in Directory.GetFiles(_tempPath))
        {
            File.Delete(file);
        }
    }

    private void CbbSourceCamera_SelectedIndexChanged(object sender, EventArgs e)
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

        CameraMatrix? cameraMatrix = Calibration.Calibrate(TxtAppId.Text, _tempPath);
        if (cameraMatrix == null)
        {
            throw new Exception("Error getting camera matrix");
        }

        MessageBox.Show("Calibration was successful");
    }
}
