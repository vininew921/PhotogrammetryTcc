using AForge.Video;
using AForge.Video.DirectShow;
using DataCollector;
using OpenTK.Mathematics;
using PhotogrammetryMath;

namespace Camera;

public partial class MainForm : Form
{
    private readonly FilterInfoCollection _filterInfoCollection;
    private readonly Guid _imageGuid;

    private VideoCaptureDevice? _videoCaptureDevice;

    public MainForm()
    {
        InitializeComponent();

        _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        foreach (FilterInfo filterInfo in _filterInfoCollection)
        {
            CbbSourceCamera.Items.Add(filterInfo.Name);
        }

        foreach (LengthType lengthType in Enum.GetValues(typeof(LengthType)))
        {
            CbbLengthType.Items.Add(lengthType.ToString());
        }

        CbbSourceCamera.SelectedIndex = 0;
        CbbLengthType.SelectedIndex = 0;

        if (!Directory.Exists("./Images"))
        {
            Directory.CreateDirectory("./Images");
        }

        _imageGuid = Guid.NewGuid();
    }

    private void BtnCaptureImage_Click(object sender, EventArgs e) => SetStaticImages((Bitmap)LiveCamImage.Image.Clone());

    private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e) => SetLiveCamImage((Bitmap)e.Frame.Clone());

    private void BtnProcessImages_Click(object sender, EventArgs e)
    {
        float cameraConstant = float.Parse(TxtFocalDistance.Text);
        LengthType lengthType = (LengthType)CbbLengthType.SelectedIndex;
        Vector3 camera1pos = new Vector3(float.Parse(TxtXAxis1.Text), float.Parse(TxtYAxis1.Text), float.Parse(TxtZAxis1.Text));
        Vector3 camera2pos = new Vector3(float.Parse(TxtXAxis2.Text), float.Parse(TxtYAxis2.Text), float.Parse(TxtZAxis2.Text));

        ImageProcessing.ProcessImages(cameraConstant, lengthType, camera1pos, camera2pos, PbImage1.Image, PbImage2.Image);
    }

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
            PbImage1.Image.Save($"./Images/{_imageGuid}-1.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        else if (PbImage2.Image == null)
        {
            PbImage2.Image = (Bitmap)image.Clone();
            PbImage2.Image.Save($"./Images/{_imageGuid}-2.png", System.Drawing.Imaging.ImageFormat.Png);
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
