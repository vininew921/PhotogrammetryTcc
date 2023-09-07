using PhotogrammetryMath.Models;

namespace StereoImage;

internal static class Extensions
{
    public static Vector2 ToVector2(this Point point) => new Vector2(point.X, point.Y);
}
