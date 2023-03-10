namespace PhotogrammetryMath;

public static class Triangulation
{
    public static float GetZ(float cameraConstant, float b, float x1, float x2)
    {
        float z = cameraConstant * (b / -(x1 - x2));
        return z;
    }

    public static float GetX(float b, float x1, float x2)
    {
        float x = x1 * (b / -(x2 - x1));
        return x;
    }

    public static float GetY(float y1, float y2, float b, float x1, float x2)
    {
        float y = y1 * (b / (-(x2 - x1)));
        return y;
    }
}
