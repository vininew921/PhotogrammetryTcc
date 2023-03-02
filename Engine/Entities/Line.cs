namespace Engine.Entities;

public class Line : Mesh
{
    public Line(Vector3 from, Vector3 to) : base(verticeCount: 3, position: Vector3.Zero, primitiveType: PrimitiveType.Lines, indices: new uint[2] { 0, 1 })
    {
        float[] _baseVertices =
        {
           from.X, from.Y, from.Z,
           to.X, to.Y, to.Z,
        };

        SetVertices(_baseVertices);

        Vao.LinkAttrib(Vbo, Ebo, 0, VerticeCount, VertexAttribPointerType.Float, 3 * sizeof(float), 0);
    }
}
