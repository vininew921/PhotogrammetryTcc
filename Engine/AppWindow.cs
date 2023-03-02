using Engine.Entities;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Engine
{
    public class AppWindow : GameWindow
    {
        private readonly List<Mesh> _meshes = new List<Mesh>();
        private Camera _camera = default!;

        public AppWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        public void AddMesh(Mesh mesh)
        {
            _meshes.Add(mesh);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);

            Mesh._camera = _camera;

            CursorState = CursorState.Grabbed;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (Mesh mesh in _meshes)
            {
                mesh.Render();
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            _camera.ProcessInput(KeyboardState, e, MouseState);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            _camera.Fov -= e.OffsetY;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);

            _camera.AspectRatio = Size.X / (float)Size.Y;
        }
    }
}