namespace Engine;

public class VAO
{
    public int Id { get; private set; }

    public VAO()
    {
        Id = GL.GenVertexArray();
    }

    public void LinkAttrib(VBO vbo, EBO ebo, uint layout, int count, VertexAttribPointerType type, int stride, int offset)
    {
        Bind();
        vbo.Bind();
        ebo.Bind();

        GL.VertexAttribPointer(layout, count, type, false, stride, offset);
        GL.EnableVertexAttribArray(layout);

        VBO.Unbind();
        Unbind();
    }

    public void Bind() => GL.BindVertexArray(Id);

    public static void Unbind() => GL.BindVertexArray(0);

    public void Delete() => GL.DeleteVertexArray(Id);
}
