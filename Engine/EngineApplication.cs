namespace Engine;

public abstract class EngineApplication
{
    private readonly NativeWindowSettings _windowSettings;
    private readonly AppWindow _appWindow;

    public EngineApplication(int windowWidth, int windowHeight, string windowTitle)
    {
        _windowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(windowWidth, windowHeight),
            Title = windowTitle,
            Flags = ContextFlags.ForwardCompatible
        };

        _appWindow = new AppWindow(GameWindowSettings.Default, _windowSettings);
        _appWindow.UpdateFrame += OnUpdate;

        OnLoad();
    }

    public virtual void OnLoad() => _appWindow.Run();

    public virtual void OnUpdate(FrameEventArgs e)
    {
    }

    public void AddMesh(Mesh mesh) => _appWindow.AddMesh(mesh);
}
