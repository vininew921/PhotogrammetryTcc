using Engine;
using Engine.Entities;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

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
        AddMesh(new Cube(Vector3.Zero));
        base.OnLoad();
    }

    public override void OnUpdate(FrameEventArgs e) => base.OnUpdate(e);
}
