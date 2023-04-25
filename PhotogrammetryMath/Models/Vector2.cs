namespace PhotogrammetryMath.Models;

public class Vector2
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vector2()
    {
    }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    public OpenTK.Mathematics.Vector2 ToOpenTKVec2() => new OpenTK.Mathematics.Vector2(X, Y);

    public static float Distance(Vector2 start, Vector2 end) => start.DistanceTo(end);
}
