namespace Engine.Entities;

public class Cube : Mesh
{
    private readonly float[] _baseVertices =
    {
        0.5f,  0.5f, 0.5f, //0 - top right front
        0.5f, -0.5f, 0.5f, //1 - bottom right front
       -0.5f, -0.5f, 0.5f, //2 - bottom left front
       -0.5f,  0.5f, 0.5f, //3 - top left front
        0.5f,  0.5f, -0.5f, //4 - top right back
        0.5f, -0.5f, -0.5f, //5 - bottom right back
       -0.5f, -0.5f, -0.5f, //6 - bottom left back
       -0.5f,  0.5f, -0.5f, //7 - top left back
    };

    public Cube(Vector3 position, float divideScale = 1) : base(verticeCount: 3, position: position, indices: new uint[36]{
                                                                                            0, 1, 2, 0, 3, 2, //front
                                                                                            0, 4, 3, 3, 7, 4, //top
                                                                                            1, 6, 5, 1, 2, 6, //bottom
                                                                                            5, 7, 6, 5, 4, 7, //back
                                                                                            6, 3, 7, 6, 2, 3, //left
                                                                                            1, 4, 5, 1, 4, 0  //right
                                                                                        })
    {
        for (int i = 0; i < _baseVertices.Length; i++)
        {
            _baseVertices[i] = _baseVertices[i] / divideScale;
        }

        SetVertices(_baseVertices);

        Vao.LinkAttrib(Vbo, Ebo, 0, VerticeCount, VertexAttribPointerType.Float, 3 * sizeof(float), 0);
    }
}
