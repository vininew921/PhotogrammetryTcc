namespace PhotogrammetryMath;

public class PinholeCamera
{
    public Vector3 Position { get; set; }
    public Vector3 Orientation { get; set; }

    /// <summary>
    /// Camera constant (focal length) in meters
    /// </summary>
    public float CameraConstant { get; private set; }

    public PinholeCamera(Vector3 position, Vector3 orientation, float cameraConstant, LengthType lengthType)
    {
        Position = position;
        Orientation = orientation;
        SetCameraConstant(cameraConstant, lengthType);
    }

    public void SetCameraConstant(float cameraConstant, LengthType lengthType)
    {
        switch (lengthType)
        {
            case LengthType.Millimiters:
                CameraConstant = cameraConstant / 1000;
                break;

            case LengthType.Centimeters:
                CameraConstant = cameraConstant / 100;
                break;

            case LengthType.Meters:
                CameraConstant = cameraConstant;
                break;
        }
    }
}

public enum LengthType
{
    Millimiters,
    Centimeters,
    Meters
}
