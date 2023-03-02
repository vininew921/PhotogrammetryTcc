namespace Engine.Entities;

public class Cube : Mesh
{
    private readonly float[] _baseVertices =
    {
        0.5f,  0.5f, 0.0f, //0 - top right front
        0.5f, -0.5f, 0.0f, //1 - bottom right front
       -0.5f, -0.5f, 0.0f, //2 - bottom left front
       -0.5f,  0.5f, 0.0f, //3 - top left front
        0.5f,  0.5f, 1.0f, //4 - top right back
        0.5f, -0.5f, 1.0f, //5 - bottom right back
       -0.5f, -0.5f, 1.0f, //6 - bottom left back
       -0.5f,  0.5f, 1.0f, //7 - top left back
    };

    public Cube(Vector3 position) : base(verticeCount: 3, position: position, indices: new uint[36]{
                                                                                        0, 1, 3, 1, 2, 3, //front
                                                                                        0, 4, 3, 3, 4, 7, //top
                                                                                        1, 2, 5, 5, 6, 2, //bottom
                                                                                        0, 4, 5, 1, 5, 0, //right
                                                                                        3, 7, 6, 2, 3, 6, //left
                                                                                        4, 5, 7, 7, 6, 5, //back
                                                                                        })
    {
        SetVertices(_baseVertices);

        Vao.LinkAttrib(Vbo, Ebo, 0, VerticeCount, VertexAttribPointerType.Float, 3 * sizeof(float), 0);
    }
}
