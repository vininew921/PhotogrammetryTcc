using Engine;
using Engine.Entities;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace Photogrammetry
{
    internal class Application : EngineApplication
    {
        private Triangle2D triangle = default!;

        public Application(int windowWidth, int windowHeight, string windowTitle) : base(windowWidth, windowHeight, windowTitle)
        {
        }

        public override void OnLoad()
        {
            triangle = new Triangle2D(Vector2.Zero);
            AddEntity(triangle);

            base.OnLoad();
        }

        public override void OnUpdate(FrameEventArgs e)
        {
            base.OnUpdate(e);
        }
    }
}