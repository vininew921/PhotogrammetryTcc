using AForge.Video;
using AForge.Video.DirectShow;
using Newtonsoft.Json;
using PhotogrammetryMath;
using PhotogrammetryMath.Models;
using Shared;
using System.Drawing.Drawing2D;

namespace StereoImage;

public partial class StereoImageForm : Form
{
    private int _totalImagesIndex = 0;
    private int _pointCount = 0;
    private int _currentPointImage = 0;
    private bool _canPickPoints = false;
    private bool _canTriangulate = false;

    private Point _currentPoint;
    private List<(Point a, Point b)> _pointPairs;
    private VideoCaptureDevice? _videoCaptureDevice;
    private CameraMatrix _cameraMatrix = default!;

    private readonly FilterInfoCollection _filterInfoCollection;
    private readonly PictureBox[] _pictures;
    private readonly int _maxImages = 2;
    private readonly int _minPointsToTriangulate = 5;

    public StereoImageForm()
    {
        InitializeComponent();
        DirectoryManager.SetupDirectories();

        TxtObjectName.Text = Guid.NewGuid().ToString();

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

        _pictures = new PictureBox[2]
        {
            PbImage1,
            PbImage2
        };

        _pointPairs = new List<(Point a, Point b)>();
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
        if (_totalImagesIndex < _maxImages)
        {
            _pictures[_totalImagesIndex].Image = (Bitmap)image.Clone();
            _totalImagesIndex++;

            CheckCompletion();
        }

        image.Dispose();
    }

    private void SetCalibrationMatrix(int index)
    {
        _cameraMatrix = (CameraMatrix)CbbCalibrations.Items[index];
        LblCameraMatrixValue.Text = _cameraMatrix.ToMatrixString();
    }

    private void CheckCompletion()
    {
        if (_totalImagesIndex == _maxImages)
        {
            _canPickPoints = true;
        }
    }

    private void SetPoint(int imageIndex, Point pos)
    {
        if (!_canPickPoints || _currentPointImage != imageIndex)
        {
            return;
        }

        _currentPointImage = _currentPointImage == 0 ? 1 : 0;

        DrawPoint(imageIndex, pos);

        //Stores in buffer if point is in image 0
        if (imageIndex == 0)
        {
            _currentPoint = pos;
            return;
        }

        //if image 0 already has a point chosen (_currentPoint),
        //create a new pair with _currentPoint and the new passed coordinates
        _pointPairs.Add((_currentPoint, pos));
        _pointCount++;

        if (_pointCount > _minPointsToTriangulate - 1)
        {
            _canTriangulate = true;
        }
    }

    private void DrawPoint(int imageIndex, Point pos)
    {
        Bitmap bmp = (Bitmap)_pictures[imageIndex].Image;

        pos.X *= bmp.Width / PbImage1.Width;
        pos.Y *= bmp.Height / PbImage1.Height;

        Graphics g = Graphics.FromImage(bmp);

        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.DrawString($"{_pointCount + 1}", new Font("Tahoma", 48), Brushes.Red, pos.X, pos.Y);
        g.FillEllipse(new SolidBrush(Color.Red), pos.X - 10, pos.Y - 10, 20, 20);

        g.Flush();

        _pictures[imageIndex].Image = bmp;
    }

    private void Triangulate()
    {
        List<Vector3> result = new List<Vector3>();
        foreach ((Point a, Point b) p in _pointPairs)
        {
            float cameraDeltaX = float.Parse(TxtXAxis1.Text) - float.Parse(TxtXAxis2.Text);

            Vector3 triangulationResult = StereoNormal.Triangulate(p.a.ToVector2(), p.b.ToVector2(), _cameraMatrix.Fx, cameraDeltaX);
            result.Add(triangulationResult);
        }

        File.WriteAllText(Path.Combine(DirectoryManager.TriangulationResults, $"{TxtObjectName.Text}.json"), JsonConvert.SerializeObject(result));
        MessageBox.Show("Triangulation Successful");
    }

    private void Reset()
    {
        _totalImagesIndex = 0;
        _pointCount = 0;
        _currentPointImage = 0;
        _canPickPoints = false;
        _canTriangulate = false;
        _pointPairs = new List<(Point a, Point b)>();

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

    private void BtnReset_Click(object sender, EventArgs e) => Reset();

    private void PbImage1_Click(object sender, EventArgs e) => SetPoint(0, PbImage1.PointToClient(MousePosition));

    private void PbImage2_Click(object sender, EventArgs e) => SetPoint(1, PbImage2.PointToClient(MousePosition));

    private void CbbCalibrations_SelectedIndexChanged(object sender, EventArgs e) => SetCalibrationMatrix(CbbCalibrations.SelectedIndex);

    private void BtnTriangulate_Click(object sender, EventArgs e)
    {
        if (!_canTriangulate)
        {
            MessageBox.Show($"Pick at least {_minPointsToTriangulate} point pairs");
            return;
        }

        Triangulate();
    }
}
