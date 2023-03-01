using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Engine.Entities
{
    public class Triangle2D : BaseEntity
    {
        private float[] baseVertices =
        {
            -0.5f , -0.5f , 0.0f, // Bottom-left vertex
             0.5f , -0.5f , 0.0f, // Bottom-right vertex
             0.0f ,  0.5f , 0.0f  // Top vertex
        };

        public Triangle2D(Vector2 position) : base(verticeCount: 3)
        {
            SetVertices(baseVertices);

            Vao.LinkAttrib(Vbo, 0, VerticeCount, VertexAttribPointerType.Float, 3 * sizeof(float), 0);
        }

        public override void SetPosition(Vector3 newPosition)
        {
            base.SetPosition(newPosition);

            SetVertices(Vertices);
        }

        public override void SetVertices(float[] vertices)
        {
            vertices[0] = baseVertices[0] + Position.X;
            vertices[1] = baseVertices[1] + Position.Y;
            vertices[3] = baseVertices[3] + Position.X;
            vertices[4] = baseVertices[4] + Position.Y;
            vertices[6] = baseVertices[6] + Position.X;
            vertices[7] = baseVertices[7] + Position.Y;

            base.SetVertices(vertices);
        }
    }
}