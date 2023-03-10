using Engine;
using Engine.Entities;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using PhotogrammetryMath;

namespace Renderer;

internal class Application : EngineApplication
{
    private readonly string[] _args;

    public Application(string[] args, int windowWidth = 800, int windowHeight = 600, string windowTitle = "Renderer") : base(windowWidth, windowHeight, windowTitle)
    {
        //TO DO: Args will contain vertex points to be rendered, add them to scene
        _args = args;
    }

    public override void OnLoad()
    {
        PinholeCamera camera1 = new PinholeCamera(new Vector3(0, 0, 0), new Vector3(0, 0, 1), 50, LengthType.Meters);
        PinholeCamera camera2 = new PinholeCamera(new Vector3(1, 0, 0), new Vector3(0, 0, 1), 50, LengthType.Meters);

        float b = (camera2.Position - camera1.Position).X;

        Console.WriteLine($"Constant = {camera1.CameraConstant}");
        Console.WriteLine($"B = {b}");

        List<(Vector2, Vector2)> points = new List<(Vector2, Vector2)>
        {
            (new Vector2(869, 349), new Vector2(1265, 349)),
            (new Vector2(1195, 95), new Vector2(1517, 95)),
            (new Vector2(305, 375), new Vector2(645, 375)),
            (new Vector2(685, 147), new Vector2(969, 147)),
            (new Vector2(505, 947), new Vector2(819, 947)),
            (new Vector2(1049, 1005), new Vector2(1403, 1005)),
            (new Vector2(1317, 661), new Vector2(1613, 661)),
        };

        List<Vector3> result = new List<Vector3>();

        foreach ((Vector2 a, Vector2 b) point in points)
        {
            float z = Triangulation.GetZ(camera1.CameraConstant, b, point.a.X, point.b.X);
            float x = Triangulation.GetX(b, point.a.X, point.b.X);
            float y = Triangulation.GetY(point.a.Y, point.b.Y, b, point.a.X, point.b.X);

            result.Add(new Vector3(x, y, z * 100));
            AddMesh(new Cube(new Vector3(x, y, z * 100), 10));
        }

        foreach (Vector3 start in result)
        {
            foreach (Vector3 end in result)
            {
                AddMesh(new Line(start, end));
            }
        }

        base.OnLoad();
    }

    public override void OnUpdate(FrameEventArgs e) => base.OnUpdate(e);
}
