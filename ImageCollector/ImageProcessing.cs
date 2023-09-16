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

    private static readonly string _imageProcessorPath = "./calibration.py";

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
        ProcessStartInfo startInfo = new ProcessStartInfo(DirectoryManager.Python)
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"\"{Path.GetFullPath(_imageProcessorPath)}\" --appId {_appId} --calibrationId {calibrationId}",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        Process? process = Process.Start(startInfo);
        process?.WaitForExit();
    }
}
