namespace PhotogrammetryMath;

public class Vector2HC
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Scalar { get; set; }

    public Vector2HC(float x, float y, float scalar = 1)
    {
        X = x;
        Y = y;
        Scalar = scalar;
        Validate();
    }

    public static Vector2HC One() => new Vector2HC(1, 1);

    public static Vector2HC Zero() => new Vector2HC(0, 0);

    public static Vector2HC Origin() => Zero();

    public static Vector2HC operator *(float scalar, Vector2HC vec)
    {
        vec.X *= scalar;
        vec.Y *= scalar;
        vec.Scalar *= scalar;
        vec.Validate();
        return vec;
    }

    public static Vector2HC operator *(Vector2HC vec, float scalar)
    {
        vec.X *= scalar;
        vec.Y *= scalar;
        vec.Scalar *= scalar;
        vec.Validate();
        return vec;
    }

    private void Validate()
    {
        if ((X * X) + (Y * Y) + (Scalar * Scalar) == 0)
        {
            throw new ArgumentException("At least one element must be different from zero");
        }
    }

    public Vector2 ToVec2()
    {
        if (Scalar == 0)
        {
            throw new ArgumentException("Scalar cannot be 0 when converting to euclidean space");
        }

        return new Vector2(X / Scalar, Y / Scalar);
    }
}
