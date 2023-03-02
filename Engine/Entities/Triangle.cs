namespace Engine.Entities;

public class Triangle : Mesh
{
    private readonly float[] _baseVertices =
    {
       -0.5f , -0.5f , 0.0f, // Bottom-left vertex
        0.5f , -0.5f , 0.0f, // Bottom-right vertex
        0.0f ,  0.8f , 0.0f  // Top vertex
    };

    public Triangle(Vector3 position) : base(verticeCount: 3, position: position, indices: new uint[3] { 0, 1, 2 })
    {
        SetVertices(_baseVertices);

        Vao.LinkAttrib(Vbo, Ebo, 0, VerticeCount, VertexAttribPointerType.Float, 3 * sizeof(float), 0);
    }
}
