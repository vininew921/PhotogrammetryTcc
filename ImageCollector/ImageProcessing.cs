using Shared;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace ImageCollector;

internal static class ImageProcessing
{
    public static float _distanceFromObject;
    public static float _cameraAngle;
    public static float _imageAngle;
    public static string _appId = string.Empty;
    public static string _appImagesDir = string.Empty;

    private static readonly string _imageProcessorPath = "./image_processing.py";
    private static readonly string _commonPointsPath = "./common_points.py";

    public static void Initialize(float distanceFromObject, float cameraAngle, float imageAngle, string appId)
    {
        _distanceFromObject = distanceFromObject;
        _cameraAngle = cameraAngle;
        _imageAngle = imageAngle;
        _appId = appId;
        _appImagesDir = Path.Combine(DirectoryManager.TemporaryImages, appId);

        if (!Directory.Exists(_appImagesDir))
        {
            Directory.CreateDirectory(_appImagesDir);
        }
    }

    public static void CaptureImage(Image image, int index)
    {
        string imagePath = Path.Combine(_appImagesDir, $"{index}.png");

        image.Save(imagePath, ImageFormat.Png);
        image.Dispose();
    }

    public static void ProcessImages(string calibrationId)
    {
        ProcessStartInfo startInfoProcessing = new ProcessStartInfo(DirectoryManager.Python)
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"\"{Path.GetFullPath(_imageProcessorPath)}\" --appid {_appId} --calibrationid {calibrationId}",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        Process? processProcessing = Process.Start(startInfoProcessing);
        processProcessing?.WaitForExit();
    }

    public static void FindCommonPoints()
    {
        ProcessStartInfo startInfoCommonPoints = new ProcessStartInfo(DirectoryManager.Python)
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"\"{Path.GetFullPath(_commonPointsPath)}\" --appid {_appId}",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        Process? processCommonPoints = Process.Start(startInfoCommonPoints);
        processCommonPoints?.WaitForExit();
    }
}
