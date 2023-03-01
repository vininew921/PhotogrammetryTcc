using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Engine.Entities
{
    public abstract class Mesh
    {
        public float[] Vertices { get; private set; } = default!;

        protected readonly VAO Vao;
        protected readonly VBO Vbo;
        protected readonly EBO Ebo;
        protected readonly Shader Shader;
        protected readonly int VerticeCount;
        protected readonly uint[] Indices;

        public Mesh(int verticeCount, uint[] indices)
        {
            Vao = new VAO();
            Vbo = new VBO();
            Ebo = new EBO(indices);
            Shader = Shader.DefaultShader;
            VerticeCount = verticeCount;
            Indices = indices;
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

            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);

            Vao.Unbind();
        }
    }
}