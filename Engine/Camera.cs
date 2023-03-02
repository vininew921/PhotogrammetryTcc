using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Engine
{
    internal class Camera
    {
        private Vector3 _front = -Vector3.UnitZ;
        private Vector3 _up = Vector3.UnitY;
        private Vector3 _right = Vector3.UnitX;

        private float _pitch;
        private float _yaw = -MathHelper.PiOver2;
        private float _fov = MathHelper.PiOver2;

        private const float cameraSpeed = 3.0f;
        private const float sensitivity = 0.2f;

        private bool _firstMove = true;
        private Vector2 _lastPos;

        public Camera(Vector3 position, float aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;
        }

        public Vector3 Position { get; set; }
        public float AspectRatio { private get; set; }
        public Vector3 Front => _front;
        public Vector3 Up => _up;
        public Vector3 Right => _right;

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(_pitch);
            set
            {
                var angle = MathHelper.Clamp(value, -89f, 89f);
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
                var angle = MathHelper.Clamp(value, 1f, 90f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + _front, _up);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.01f, 100f);
        }

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
                Position += Front * cameraSpeed * (float)e.Time; // Forward
            }

            if (input.IsKeyDown(Keys.S))
            {
                Position -= Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Keys.A))
            {
                Position -= Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Keys.D))
            {
                Position += Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Keys.Space))
            {
                Position += Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                Position -= Up * cameraSpeed * (float)e.Time; // Down
            }

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                Yaw += deltaX * sensitivity;
                Pitch -= deltaY * sensitivity;
            }
        }
    }
}