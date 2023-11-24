using AForge.Video;
using AForge.Video.DirectShow;
using ImageCollector;
using Photogrammetry;
using Shared;

namespace StereoImage;

public partial class ImageCollector : Form
{
    private VideoCaptureDevice? _videoCaptureDevice = default!;
    private List<FilterInfo> _filterInfoCollection = default!;

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
        CbbSerialPort.Items.AddRange(RotatingBoard.AVAILABLE_PORTS);

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
        CbbSerialPort.SelectedIndex = 0;
    }

    private void StartProcess()
    {
        float imageAngle = float.Parse(TxtImageAngle.Text);

        BeginInvoke(new Action(() => EnableInputs(false)));

        ImageProcessing.Initialize(TxtObjectName.Text);

        int imageQty = Convert.ToInt32(360.0f / imageAngle);

        for (int i = 0; i < imageQty; i++)
        {
            BeginInvoke(new Action(() =>
                LblProcessStatus.Text = $"Taking picture {i + 1} of {imageQty}"
            ));

            lock (LiveCamImage)
            {
                try
                {
                    BeginInvoke(new Action(() =>
                    {
                        bool worked = false;
                        while (!worked)
                        {
                            try
                            {
                                ImageProcessing.CaptureImage((Image)LiveCamImage.Image.Clone(), i);
                            }
                            catch
                            {
                                continue;
                            }

                            worked = true;
                        }
                    }
                    ));
                }
                catch { }
            }

            RotatingBoard.Rotate(imageAngle);
        }

        BeginInvoke(new Action(() =>
            LblProcessStatus.Text = $"Processing images with python"
        ));

        BeginInvoke(new Action(() =>
            ImageProcessing.ProcessImages(CbbCalibrations.Text)
        ));

        BeginInvoke(new Action(() =>
            LblProcessStatus.Text = $"Finding common points"
        ));

        BeginInvoke(new Action(() =>
            ImageProcessing.FindCommonPoints()
        ));

        BeginInvoke(new Action(() =>
            LblProcessStatus.Text = $"Done!"
        ));

        BeginInvoke(new Action(() => EnableInputs(true)));
    }

    private void EnableInputs(bool enable)
    {
        BtnStartProcess.Enabled = enable;
        BtnTestSerialPort.Enabled = enable;

        CbbSerialPort.Enabled = enable;
        CbbCalibrations.Enabled = enable;
        CbbCameraResolution.Enabled = enable;
        CbbSourceCamera.Enabled = enable;

        TxtImageAngle.Enabled = enable;
        TxtObjectName.Enabled = enable;
    }

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e) => SetLiveCamImage((Bitmap)e.Frame.Clone());

    private void SetLiveCamImage(Bitmap newImageBitmap)
    {
        LiveCamImage.Image?.Dispose();
        LiveCamImage.Image = newImageBitmap;
    }

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

            _videoCaptureDevice.SetCameraProperty(CameraControlProperty.Focus, 10, CameraControlFlags.Manual);
            _videoCaptureDevice.Start();
        }
    }

    private void CbbSourceCamera_SelectedIndexChanged(object sender, EventArgs e)
    {
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
        Done();
        InitVideo();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        Done();
    }

    private void BtnStartProcess_Click(object sender, EventArgs e) => new Thread(StartProcess).Start();

    private void CbbSerialPort_SelectedIndexChanged(object sender, EventArgs e) => RotatingBoard.SetPort(CbbSerialPort.SelectedIndex);

    private void BtnTestSerialPort_Click(object sender, EventArgs e)
    {
        EnableInputs(false);

        try
        {
            RotatingBoard.Rotate(360);
        }
        catch
        {
            MessageBox.Show("Error sending serial message to selected port");
        }

        EnableInputs(true);
    }

    private void TrbFocus_Scroll(object sender, EventArgs e)
    {
        if (_videoCaptureDevice == null)
        {
            return;
        }

        LblFocus.Text = $"Focus - {TrbFocus.Value}";
        _videoCaptureDevice.SetCameraProperty(CameraControlProperty.Focus, TrbFocus.Value, CameraControlFlags.Manual);
    }
}
