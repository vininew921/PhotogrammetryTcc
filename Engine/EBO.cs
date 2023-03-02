namespace Engine;

public class EBO
{
    public int Id { get; set; }

    public EBO(uint[] indices)
    {
        Id = GL.GenBuffer();

        Bind();

        GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(uint) * indices.Length, indices, BufferUsageHint.StaticDraw);

        Unbind();
    }

    public void Bind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, Id);

    public static void Unbind() => GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

    public void Delete() => GL.DeleteBuffer(Id);
}
