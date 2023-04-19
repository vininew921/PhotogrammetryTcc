namespace Engine;

internal class Camera
{
    private Vector3 _front = -Vector3.UnitZ;
    private Vector3 _up = Vector3.UnitY;
    private Vector3 _right = Vector3.UnitX;
    private Vector3 _position;

    private float _aspectRatio;
    private float _pitch;
    private float _yaw = -MathHelper.PiOver2;
    private float _fov = MathHelper.PiOver2;
    private Vector2 _lastPos;

    private const float _cameraSpeed = 10.0f;
    private const float _sensitivity = 0.2f;

    public Camera(Vector3 position, float aspectRatio, MouseState mouse)
    {
        _position = position;
        _aspectRatio = aspectRatio;

        _lastPos = new Vector2(mouse.X, mouse.Y);
    }

    public float Pitch
    {
        get => MathHelper.RadiansToDegrees(_pitch);
        set
        {
            float angle = MathHelper.Clamp(value, -89f, 89f);
            _pitch = MathHelper.DegreesToRadians(angle);
            UpdateVectors();
        }
    }

    public float Yaw
    {
        get => MathHelper.RadiansToDegrees(_yaw);
        set
        {
            _yaw = MathHelper.DegreesToRadians(value);
            UpdateVectors();
        }
    }

    public float Fov
    {
        get => MathHelper.RadiansToDegrees(_fov);
        set
        {
            float angle = MathHelper.Clamp(value, 1f, 90f);
            _fov = MathHelper.DegreesToRadians(angle);
        }
    }

    public Matrix4 GetViewMatrix() => Matrix4.LookAt(_position, _position + _front, _up);

    public Matrix4 GetProjectionMatrix() => Matrix4.CreatePerspectiveFieldOfView(_fov, _aspectRatio, 0.01f, 100f);

    private void UpdateVectors()
    {
        _front.X = MathF.Cos(_pitch) * MathF.Cos(_yaw);
        _front.Y = MathF.Sin(_pitch);
        _front.Z = MathF.Cos(_pitch) * MathF.Sin(_yaw);

        _front = Vector3.Normalize(_front);
        _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));

        _up = Vector3.Normalize(Vector3.Cross(_right, _front));
    }

    public void ProcessInput(KeyboardState input, FrameEventArgs e, MouseState mouse)
    {
        if (input.IsKeyDown(Keys.W))
        {
            _position += _front * _cameraSpeed * (float)e.Time; // Forward
        }

        if (input.IsKeyDown(Keys.S))
        {
            _position -= _front * _cameraSpeed * (float)e.Time; // Backwards
        }

        if (input.IsKeyDown(Keys.A))
        {
            _position -= _right * _cameraSpeed * (float)e.Time; // Left
        }

        if (input.IsKeyDown(Keys.D))
        {
            _position += _right * _cameraSpeed * (float)e.Time; // _right
        }

        if (input.IsKeyDown(Keys.Space))
        {
            _position += _up * _cameraSpeed * (float)e.Time; // _up
        }

        if (input.IsKeyDown(Keys.LeftShift))
        {
            _position -= _up * _cameraSpeed * (float)e.Time; // Down
        }

        float deltaX = mouse.X - _lastPos.X;
        float deltaY = mouse.Y - _lastPos.Y;

        _lastPos = new Vector2(mouse.X, mouse.Y);

        Yaw += deltaX * _sensitivity;
        Pitch -= deltaY * _sensitivity;
    }

    public void OnMouseWheel(MouseWheelEventArgs e) => Fov -= e.OffsetY;

    public void OnResize(int sizeX, int sizeY) => _aspectRatio = sizeX / (float)sizeY;
}
