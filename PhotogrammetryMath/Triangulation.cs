namespace PhotogrammetryMath;

public static class Triangulation
{
    public static float GetX(float b, float x1, float x2)
    {
        float x = x1 * (b / (-(x2 - x1)));
        return x;
    }

    public static float GetY(float y1, float y2, float b, float x1, float x2)
    {
        float y = ((y1 + y2) / 2) * (b / (-(x2 - x1)));
        return y;
    }

    public static float GetZ(float cameraConstant, float b, float x1, float x2)
    {
        float z = cameraConstant * (b / (-(x2 - x1)));
        return z;
    }

    public static Vector3 Triangulate(Vector2 pointA, Vector2 pointB, float cameraConstant, float cameraDeltaX)
    {
        float z = GetZ(cameraConstant, cameraDeltaX, pointA.X, pointB.X);
        float x = GetX(cameraDeltaX, pointA.X, pointB.X);
        float y = GetY(pointA.Y, pointB.Y, cameraDeltaX, pointA.X, pointB.X);

        return new Vector3(x, y, z);
    }
}
