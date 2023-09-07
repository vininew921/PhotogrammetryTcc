using Shared;
using System.Drawing.Imaging;

namespace ImageCollector;

internal static class ImageProcessing
{
    public static float _distanceFromObject;
    public static float _cameraAngle;
    public static float _imageAngle;
    public static string _appImagesDir = string.Empty;

    public static void Initialize(float distanceFromObject, float cameraAngle, float imageAngle, string appId)
    {
        _distanceFromObject = distanceFromObject;
        _cameraAngle = cameraAngle;
        _imageAngle = imageAngle;
        _appImagesDir = Path.Combine(DirectoryManager.TemporaryImages, appId);

        if (!Directory.Exists(_appImagesDir))
        {
            Directory.CreateDirectory(_appImagesDir);
        }
    }

    public static Image ProcessImage(Image image, int index)
    {
        string imagePath = Path.Combine(_appImagesDir, $"{index}.png");

        Image result = (Image)image.Clone();

        image.Save(imagePath, ImageFormat.Png);
        image.Dispose();

        return result;
    }
}
