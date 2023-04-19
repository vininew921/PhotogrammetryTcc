namespace PhotogrammetryMath;

public class Vector3HC
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Scalar { get; set; }

    public Vector3HC(float x, float y, float z, float scalar = 1)
    {
        X = x;
        Y = y;
        Z = z;
        Scalar = scalar;
        Validate();
    }

    public static Vector3HC One() => new Vector3HC(1, 1, 1);

    public static Vector3HC Zero() => new Vector3HC(0, 0, 0);

    public static Vector3HC Origin() => Zero();

    public static Vector3HC operator *(float scalar, Vector3HC vec)
    {
        vec.X *= scalar;
        vec.Y *= scalar;
        vec.Z *= scalar;
        vec.Scalar *= scalar;
        vec.Validate();
        return vec;
    }

    public static Vector3HC operator *(Vector3HC vec, float scalar)
    {
        vec.X *= scalar;
        vec.Y *= scalar;
        vec.Z *= scalar;
        vec.Scalar *= scalar;
        vec.Validate();
        return vec;
    }

    private void Validate()
    {
        if ((X * X) + (Y * Y) + (Z * Z) + (Scalar * Scalar) == 0)
        {
            throw new ArgumentException("At least one element must be different from zero");
        }
    }

    public Vector3 ToVec3()
    {
        if (Scalar == 0)
        {
            throw new ArgumentException("Scalar cannot be 0 when converting to euclidean space");
        }

        return new Vector3(X / Scalar, Y / Scalar, Z / Scalar);
    }
}
