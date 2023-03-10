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
        PinholeCamera camera1 = new PinholeCamera(new Vector3(0, 0, 0), new Vector3(0, 0, 1), 50, LengthType.Millimiters);
        PinholeCamera camera2 = new PinholeCamera(new Vector3(1, 0, 0), new Vector3(0, 0, 1), 50, LengthType.Millimiters);

        float b = 1;

        Console.WriteLine($"Constant = {camera1.CameraConstant}");
        Console.WriteLine($"B = {b}");

        Vector2 cube1a = new Vector2(1265, 350);
        Vector2 cube1b = new Vector2(646, 374);
        Vector2 cube1c = new Vector2(1518, 96);
        Vector2 cube1d = new Vector2(969, 146);
        Vector2 cube1e = new Vector2(1403, 1005);

        Vector2 cube2a = new Vector2(869, 350);
        Vector2 cube2b = new Vector2(304, 374);
        Vector2 cube2c = new Vector2(1195, 96);
        Vector2 cube2d = new Vector2(684, 146);
        Vector2 cube2e = new Vector2(1047, 1005);

        List<(Vector2, Vector2)> points = new List<(Vector2, Vector2)>
        {
            (cube1a, cube2a),
            (cube1b, cube2b),
            (cube1c, cube2c),
            (cube1d, cube2d),
            (cube1e, cube2e),
        };

        foreach ((Vector2 a, Vector2 b) point in points)
        {
            float z = Triangulation.GetZ(camera1.CameraConstant, b, point.a.X, point.b.X);
            float x = Triangulation.GetX(b, point.a.X, point.b.X);
            float y = Triangulation.GetY(point.a.Y, point.b.Y, b, point.a.X, point.b.X);

            Vector3 result = new Vector3(x, y, z);
            Console.WriteLine(result);
            AddMesh(new Cube(result, 10));
        }

        base.OnLoad();
    }

    public override void OnUpdate(FrameEventArgs e) => base.OnUpdate(e);
}
