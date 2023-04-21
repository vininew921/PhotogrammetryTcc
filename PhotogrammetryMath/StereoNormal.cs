namespace PhotogrammetryMath;

/// <summary>
/// Methods for triangulating the Stereo Normal case, where the difference between
/// the two cameras is only the X axis (x_parallax)
/// </summary>
public static class StereoNormal
{
    private static float GetX(float x1, float imageScaleNumber) => x1 * imageScaleNumber;

    private static float GetY(float y1, float y2, float imageScaleNumber) => (y1 + y2) / 2 * imageScaleNumber;

    private static float GetZ(float cameraConstant, float imageScaleNumber) => cameraConstant * imageScaleNumber;

    private static float X_Parallax(Vector2 pointA, Vector2 pointB) => pointB.X - pointA.X;

    private static float ImageScaleNumber(float projectionCenterDistance, float x_parallax) => projectionCenterDistance / -x_parallax;

    public static Vector3 Triangulate(Vector2 pointA, Vector2 pointB, float cameraConstant, float projectionCenterDistance)
    {
        float x_parallax = X_Parallax(pointA, pointB);
        float imageScaleNumber = ImageScaleNumber(projectionCenterDistance, x_parallax);

        float z = GetZ(cameraConstant, imageScaleNumber);
        float x = GetX(pointA.X, imageScaleNumber);
        float y = GetY(pointA.Y, pointB.Y, imageScaleNumber);

        return new Vector3(x, y, z);
    }
}
