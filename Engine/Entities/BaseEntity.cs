using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Engine.Entities
{
    public abstract class BaseEntity
    {
        public Vector3 Position { get; private set; }
        public float[] Vertices { get; private set; } = default!;

        protected readonly VAO Vao;
        protected readonly VBO Vbo;
        protected readonly Shader Shader;
        protected readonly int VerticeCount;

        public BaseEntity(int verticeCount)
        {
            Vao = new VAO();
            Vbo = new VBO();
            Shader = new Shader("Shaders/defaultShader.vert", "Shaders/defaultShader.frag");
            VerticeCount = verticeCount;
        }

        public virtual void SetVertices(float[] vertices)
        {
            Vertices = vertices;

            Vbo.SetBufferData(Vertices);
        }

        public virtual void SetPosition(Vector3 newPosition)
        {
            Position = newPosition;
        }

        internal void Render()
        {
            Shader.Use();
            Vao.Bind();

            GL.DrawArrays(PrimitiveType.Triangles, 0, VerticeCount);
        }
    }
}