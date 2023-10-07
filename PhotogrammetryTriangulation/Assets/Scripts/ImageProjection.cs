using System.IO;
using UnityEngine;

public class ImageProjection : MonoBehaviour
{
    public Vector3 ProjectionCenter;

    private Vector3 _objectCenter;
    private float _rotation;
    private Sprite _sprite;
    private SpriteRenderer _spriteRenderer;

    public ImageProjection Load(string imagePath, float rotation, Vector3 objectCenter)
    {
        _rotation = rotation;

        // Load the image texture from the file path
        _sprite = LoadSprite(imagePath);

        if (_sprite != null)
        {
            if (TryGetComponent(out SpriteRenderer renderer))
            {
                renderer.sprite = _sprite;
                _spriteRenderer = renderer;
            }
            else
            {
                Debug.LogError("MeshRenderer component not found on the GameObject.");
            }
        }
        else
        {
            Debug.LogError("Failed to load the texture from the specified path: " + imagePath);
        }

        _objectCenter = objectCenter;

        transform.position = (Vector3.forward * 20) + _objectCenter;
        transform.RotateAround(_objectCenter, Vector3.up, _rotation);
        transform.LookAt(_objectCenter);
        transform.localScale = Vector3.one;

        return this;
    }

    public void UpdatePosition(float projectionScale, float projectionDistance, float projectionCenterDistance)
    {
        transform.position = (Vector3.forward * projectionDistance) + _objectCenter;
        transform.RotateAround(_objectCenter, Vector3.up, _rotation);
        transform.LookAt(_objectCenter);
        transform.localScale = Vector3.one * projectionScale;

        Vector3 direction = _objectCenter - transform.position;
        direction.Normalize();
        ProjectionCenter = -direction * projectionCenterDistance;
    }

    public Color GetPixelColor(float px, float py) => _spriteRenderer.sprite.texture.GetPixel(Mathf.FloorToInt(px), Mathf.FloorToInt(py));

    public Vector3 GetPixelPosition(float px, float py)
    {
        Vector2 pixelCoordinates = new Vector2(px, py);

        // Get the dimensions of the sprite in pixels.
        float spriteWidth = _spriteRenderer.sprite.texture.width;
        float spriteHeight = _spriteRenderer.sprite.texture.height;

        // Convert pixel coordinates to normalized coordinates (values between 0 and 1).
        float normalizedX = pixelCoordinates.x / spriteWidth;
        float normalizedY = pixelCoordinates.y / spriteHeight;

        // Use the normalized coordinates to find the local position within the sprite's bounds.
        Vector3 localPosition = new Vector3(
            (normalizedX - 0.5f) * _spriteRenderer.sprite.bounds.size.x,
            (normalizedY - 0.5f) * _spriteRenderer.sprite.bounds.size.y,
            0f // Assuming z-coordinate of the sprite is 0.
        );

        // Transform the local position to world space.
        Vector3 worldPosition = _spriteRenderer.transform.TransformPoint(localPosition);

        // Create a GameObject to visualize the point.
        //GameObject dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //dot.transform.position = worldPosition;
        //dot.transform.localScale = Vector3.one * 0.1f; // Adjust the scale of the dot as needed.

        return worldPosition;
    }

    // Load a texture from the specified file path
    private Sprite LoadSprite(string path)
    {
        // Load the image from the Resources folder
        Texture2D texture = new Texture2D(2, 2);
        byte[] fileData = File.ReadAllBytes(path);

        texture.LoadImage(fileData);

        if (texture == null)
        {
            Debug.LogError("Texture not found at path: " + path);
        }

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
