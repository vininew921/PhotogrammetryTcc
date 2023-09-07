using AForge.Video;
using AForge.Video.DirectShow;
using ImageCollector;
using PhotogrammetryMath;
using PhotogrammetryMath.Models;
using Shared;

namespace StereoImage;

public partial class ImageCollector : Form
{
    private VideoCaptureDevice? _videoCaptureDevice = default!;
    private List<FilterInfo> _filterInfoCollection = default!;
    private CameraMatrix _cameraMatrix = default!;

    public ImageCollector()
    {
        InitializeComponent();
        DirectoryManager.SetupDirectories();
        InitializeComboBoxes();

        TxtObjectName.Text = Guid.NewGuid().ToString();

        CbbSourceCamera.SelectedIndex = 0;

        if (!Directory.Exists("./Images"))
        {
            Directory.CreateDirectory("./Images");
        }
    }

    private void InitializeComboBoxes()
    {
        CbbCalibrations.Items.AddRange(Calibration.GetAvailableCalibrations().ToArray());

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
        CbbCalibrations.SelectedIndex = 0;
    }

    private void StartProcess()
    {
        float distanceFromObject = float.Parse(TxtCameraDistance.Text);
        float cameraAngle = float.Parse(TxtCameraAngle.Text);
        float imageAngle = float.Parse(TxtImageAngle.Text);

        BlockInputs(false);

        ImageProcessing.Initialize(distanceFromObject, cameraAngle, imageAngle, TxtObjectName.Text);

        int imageQty = Convert.ToInt32(360.0f / imageAngle);

        for (int i = 0; i < imageQty; i++)
        {
            ImageProcessing.ProcessImage((Bitmap)LiveCamImage.Image.Clone(), i);
            RotatingBoard.Rotate(imageAngle);
        }

        BlockInputs(true);
    }

    private void BlockInputs(bool unlock)
    {
        BtnStartProcess.Enabled = unlock;
        TxtCameraAngle.Enabled = unlock;
        TxtCameraDistance.Enabled = unlock;
        TxtImageAngle.Enabled = unlock;
        TxtObjectName.Enabled = unlock;
    }

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e) => SetLiveCamImage((Bitmap)e.Frame.Clone());

    private void SetLiveCamImage(Bitmap newImageBitmap)
    {
        LiveCamImage.Image?.Dispose();
        LiveCamImage.Image = newImageBitmap;
    }

    private void SetProcessedImage(Bitmap newImageBitmap)
    {
        PbProcessedImage.Image?.Dispose();
        PbProcessedImage.Image = newImageBitmap;
    }

    private void SetCalibrationMatrix(int index)
    {
        _cameraMatrix = (CameraMatrix)CbbCalibrations.Items[index];
        LblCameraMatrixValue.Text = _cameraMatrix.ToMatrixString();
    }

    private void Reset() => PbProcessedImage?.Image?.Dispose();

    private void Done()
    {
        if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
        {
            _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.SignalToStop();
            _videoCaptureDevice.WaitForStop();
            _videoCaptureDevice = null;
        }
    }

    private void InitVideo()
    {
        if (_videoCaptureDevice == null)
        {
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[CbbSourceCamera.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities[CbbCameraResolution.SelectedIndex == -1 ? 0 : CbbCameraResolution.SelectedIndex];

            _videoCaptureDevice.SetCameraProperty(CameraControlProperty.Focus, 1, CameraControlFlags.Manual);
            _videoCaptureDevice.Start();
        }
    }

    private void CbbSourceCamera_SelectedIndexChanged(object sender, EventArgs e)
    {
        Reset();
        Done();
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
        Done();
        InitVideo();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        Done();
    }

    private void BtnReset_Click(object sender, EventArgs e) => Reset();

    private void CbbCalibrations_SelectedIndexChanged(object sender, EventArgs e) => SetCalibrationMatrix(CbbCalibrations.SelectedIndex);

    private void BtnStartProcess_Click(object sender, EventArgs e) => StartProcess();
}
