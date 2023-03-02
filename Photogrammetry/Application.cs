using Engine;
using Engine.Entities;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace Photogrammetry
{
    internal class Application : EngineApplication
    {
        public Application(int windowWidth, int windowHeight, string windowTitle) : base(windowWidth, windowHeight, windowTitle)
        {
        }

        public override void OnLoad()
        {
            AddMesh(new Cube(Vector3.Zero));
            base.OnLoad();
        }

        public override void OnUpdate(FrameEventArgs e)
        {
            base.OnUpdate(e);
        }
    }
}