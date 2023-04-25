using OpenTK.Mathematics;

namespace PhotogrammetryMath.Models;

public class CameraMatrix
{
    public float Fx { get; set; }
    public float Fy { get; set; }
    public float S { get; set; }
    public float X0 { get; set; }
    public float Y0 { get; set; }
    public string Id { get; set; } = default!;

    public CameraMatrix()
    { }

    public CameraMatrix(float fx, float fy, float s, float x0, float y0, string id)
    {
        Fx = fx;
        Fy = fy;
        S = s;
        X0 = x0;
        Y0 = y0;
        Id = id;
    }

    public Matrix3 ToMatrix() => new Matrix3(Fx, S, X0, 0, Fy, Y0, 0, 0, 1);

    public Vector2 ProjectionCenter() => new Vector2(X0, Y0);

    public string ToMatrixString() => $"Focal Length X: {Fx}\nFocal Length Y: {Fy}\nOptical Center X: {X0}\nOptical Center Y: {Y0}\nSkew: {S}";

    public override string ToString() => Id;
}
