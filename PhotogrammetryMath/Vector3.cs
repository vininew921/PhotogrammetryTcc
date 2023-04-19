namespace PhotogrammetryMath;

public class Vector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3()
    {
    }

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public OpenTK.Mathematics.Vector3 ToOpenTKVec3() => new OpenTK.Mathematics.Vector3(X, Y, Z);

    public static float Distance(Vector3 start, Vector3 end) => start.DistanceTo(end);
}
