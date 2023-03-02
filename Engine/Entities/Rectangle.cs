namespace Engine.Entities;

public class Rectangle : Mesh
{
    private readonly float[] _baseVertices =
    {
        0.5f,  0.5f, 0.0f, // top right
        0.5f, -0.5f, 0.0f, // bottom right
       -0.5f, -0.5f, 0.0f, // bottom left
       -0.5f,  0.5f, 0.0f, // top left
    };

    public Rectangle(Vector3 position) : base(verticeCount: 3, position: position, indices: new uint[6] { 0, 1, 3, 1, 2, 3 })
    {
        SetVertices(_baseVertices);

        Vao.LinkAttrib(Vbo, Ebo, 0, VerticeCount, VertexAttribPointerType.Float, 3 * sizeof(float), 0);
    }
}
