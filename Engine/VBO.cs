namespace Engine;

public class VBO
{
    public int Id { get; private set; }

    public VBO()
    {
        Id = GL.GenBuffer();
    }

    public void SetBufferData(float[] vertices)
    {
        Bind();

        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        Unbind();
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ArrayBuffer, Id);

    public static void Unbind() => GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

    public void Delete() => GL.DeleteBuffer(Id);
}
