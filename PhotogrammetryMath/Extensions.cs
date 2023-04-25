using PhotogrammetryMath.Models;

namespace PhotogrammetryMath;

public static class Extensions
{
    public static float DistanceTo(this Vector3 from, Vector3 to)
    {
        float deltaX = to.X - from.X;
        float deltaY = to.Y - from.Y;
        float deltaZ = to.Z - from.Z;

        return MathF.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
    }

    public static float DistanceTo(this Vector2 from, Vector2 to)
    {
        float deltaX = to.X - from.X;
        float deltaY = to.Y - from.Y;

        return MathF.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
    }
}
