using OpenTK.Mathematics;
using PhotogrammetryMath;

namespace DataCollector;

internal static class ImageProcessing
{
    public static void ProcessImages(float cameraConstant, LengthType lengthType, Vector3 camera1pos, Vector3 camera2pos, Image image1, Image image2)
    {
        Vector3 orientation = Vector3.UnitZ;

        PinholeCamera camera1 = new PinholeCamera(camera1pos / 100, orientation, cameraConstant, lengthType);
        PinholeCamera camera2 = new PinholeCamera(camera2pos / 100, orientation, cameraConstant, lengthType);

        Matching.CrossCorrelation(camera1, camera2, (Bitmap)image1, (Bitmap)image2);
    }
}
