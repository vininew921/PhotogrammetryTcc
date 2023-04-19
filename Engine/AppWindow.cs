namespace Engine;

public class AppWindow : GameWindow
{
    private readonly List<Mesh> _meshes = new List<Mesh>();
    private Camera _camera = default!;
    private bool _wireframe = false;

    public AppWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
    }

    public void AddMesh(Mesh mesh) => _meshes.Add(mesh);

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        GL.Enable(EnableCap.DepthTest);
        GL.Enable(EnableCap.Multisample);

        _camera = new Camera(Vec3.UnitZ, Size.X / (float)Size.Y, MouseState);

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

        if (KeyboardState.IsKeyPressed(Keys.H))
        {
            if (!_wireframe)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            }
            else
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            }

            _wireframe = !_wireframe;
        }

        _camera.ProcessInput(KeyboardState, e, MouseState);
    }

    protected override void OnMouseWheel(MouseWheelEventArgs e)
    {
        base.OnMouseWheel(e);

        _camera.OnMouseWheel(e);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        GL.Viewport(0, 0, Size.X, Size.Y);

        _camera.OnResize(Size.X, Size.Y);
    }
}
