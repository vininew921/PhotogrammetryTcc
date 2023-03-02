namespace Engine.Entities;

public abstract class Mesh
{
    internal static Camera _camera = default!;

    public float[] Vertices { get; private set; } = default!;
    public Vector3 Position = Vector3.Zero;

    protected readonly VAO Vao;
    protected readonly VBO Vbo;
    protected readonly EBO Ebo;
    protected readonly Shader Shader;
    protected readonly int VerticeCount;
    protected readonly uint[] Indices;

    private readonly PrimitiveType _primitiveType;

    public Mesh(int verticeCount, uint[] indices, Vector3 position, PrimitiveType primitiveType = PrimitiveType.Triangles)
    {
        Vao = new VAO();
        Vbo = new VBO();
        Ebo = new EBO(indices);
        Shader = Shader.DefaultShader;
        VerticeCount = verticeCount;
        Indices = indices;
        Position = position;
        _primitiveType = primitiveType;
    }

    public virtual void SetVertices(float[] vertices)
    {
        Vertices = vertices;

        Vbo.SetBufferData(Vertices);
    }

    internal void Render()
    {
        Shader.Use();
        Vao.Bind();

        Shader.SetMatrix4("model", Matrix4.Identity * Matrix4.CreateTranslation(Position));
        Shader.SetMatrix4("view", _camera.GetViewMatrix());
        Shader.SetMatrix4("projection", _camera.GetProjectionMatrix());

        GL.DrawElements(_primitiveType, Indices.Length, DrawElementsType.UnsignedInt, 0);

        VAO.Unbind();
    }
}
