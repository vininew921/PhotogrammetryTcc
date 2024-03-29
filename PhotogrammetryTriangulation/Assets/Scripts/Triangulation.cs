using Assets.Scripts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Triangulation : MonoBehaviour
{
    private List<GameObject>[] _intersections;
    private List<PlyPoint> _currentPointCloud;
    private List<CommonPoint> _commonPoints;
    private ImageProjection[] _projections;

    public Slider PrimitiveScaleSlider;
    public Slider ProjectionCenterDistanceSlider;
    public Slider ProjectionDistanceSlider;
    public Slider ProjectionScaleSlider;
    public Slider CullingDistanceSlider;
    public Text PrimitiveScaleText;
    public Text ProjectionCenterDistanceText;
    public Text ProjectionDistanceText;
    public Text ProjectionScaleText;
    public Text CullingDistanceText;
    public Dropdown AvailableObjects;

    public GameObject ObjectCenter;
    public GameObject LineIntersection;
    public ImageProjection projectionPrefab;

    public bool ShowCullDistance = true;

    private void Start()
    {
        string dataAssetPath = Application.streamingAssetsPath;
        List<string> _availableObjects = Directory.EnumerateDirectories(DirectoryManager.TemporaryImages).
                                            Select(path => Path.GetFileName(path)).ToList();

        AvailableObjects.AddOptions(_availableObjects);

        UpdateUiValues();
    }

    public void LoadPointCloud()
    {
        if (AvailableObjects.value == 0)
        {
            return;
        }

        AvailableObjects.Hide();
        ClearPointCloud();

        string workingDir = Path.Combine(
            DirectoryManager.TemporaryImages,
            AvailableObjects.options[AvailableObjects.value].text,
            "processed_images");

        int imageCount = Directory.GetFiles(workingDir).Where(x => Path.GetExtension(x) == ".png").Count();

        _projections = new ImageProjection[imageCount];

        for (int i = 0; i < imageCount; i++)
        {
            ImageProjection imageProjection = Instantiate(projectionPrefab)
                                              .Load(Path.Combine(workingDir, $"{i}.png"), i * (360 / imageCount), ObjectCenter.transform.position);

            imageProjection.gameObject.SetActive(false);
            _projections[i] = imageProjection;
        }

        _commonPoints = JsonConvert.DeserializeObject<List<CommonPoint>>(File.ReadAllText(Path.Combine(workingDir, "common_keypoints.json")));

        _intersections = new List<GameObject>[imageCount];

        for (int i = 0; i < _intersections.Length; i++)
        {
            _intersections[i] = new List<GameObject>();
            for (int j = 0; j < _commonPoints.Where(x => x.ImageA == i).Count(); j++)
            {
                _intersections[i].Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            }
        }

        RenderPointCloud();
    }

    public void ClearPointCloud()
    {
        if (_intersections == null || _projections == null)
        {
            return;
        }

        for (int i = 0; i < _intersections.Length; i++)
        {
            for (int j = 0; j < _intersections[i].Count; j++)
            {
                Destroy(_intersections[i][j]);
            }
        }

        for (int i = 0; i < _projections.Length; i++)
        {
            Destroy(_projections[i].gameObject);
        }
    }

    public void UpdateUiValues()
    {
        PrimitiveScaleText.text = $"Primitive Scale - {PrimitiveScaleSlider.value:0.000}";
        ProjectionCenterDistanceText.text = $"Projection Center - {ProjectionCenterDistanceSlider.value:0.000}";
        ProjectionDistanceText.text = $"Projection Distance - {ProjectionDistanceSlider.value:0.000}";
        ProjectionScaleText.text = $"Projection Scale - {ProjectionScaleSlider.value:0.000}";
        CullingDistanceText.text = $"Culling Distance - {CullingDistanceSlider.value:0.000}";
    }

    public void RenderPointCloud()
    {
        UpdateUiValues();

        if (AvailableObjects.value == 0)
        {
            return;
        }

        if (_intersections == null || _projections == null)
        {
            return;
        }

        Triangulate();
    }

    public void ApplyCulling()
    {
        if (AvailableObjects.value == 0)
        {
            return;
        }

        UpdateUiValues();

        for (int i = 0; i < _intersections.Length; i++)
        {
            for (int j = 0; j < _intersections[i].Count; j++)
            {
                if (Vector3.Distance(_intersections[i][j].transform.position, ObjectCenter.transform.position) > CullingDistanceSlider.value)
                {
                    _intersections[i][j].SetActive(false);
                    continue;
                }

                _intersections[i][j].SetActive(true);
            }
        }
    }

    public void Triangulate()
    {
        int totalCpCount = 0;

        List<PlyPoint> points = new();

        for (int i = 0; i < _projections.Length - 1; i++)
        {
            _projections[i].UpdatePosition(-ProjectionScaleSlider.value, ProjectionDistanceSlider.value, ProjectionCenterDistanceSlider.value);
            _projections[i + 1].UpdatePosition(-ProjectionScaleSlider.value, ProjectionDistanceSlider.value, ProjectionCenterDistanceSlider.value);

            int cpCount = 0;
            foreach (CommonPoint cp in _commonPoints.Where(x => x.ImageA == i))
            {
                Color pixelColorA = _projections[i].GetPixelColor(cp.Coordinates.Ax, cp.Coordinates.Ay);
                Color pixelColorB = _projections[i + 1].GetPixelColor(cp.Coordinates.Ax, cp.Coordinates.Ay);
                Color pixelColor = 0.5f * (pixelColorA + pixelColorB);

                Vector3 origin1 = _projections[i].GetPixelPosition(cp.Coordinates.Ax, cp.Coordinates.Ay);
                Vector3 origin2 = _projections[i + 1].GetPixelPosition(cp.Coordinates.Bx, cp.Coordinates.By);

                Vector3 dir1 = _projections[i].ProjectionCenter - origin1;
                Vector3 dir2 = _projections[i + 1].ProjectionCenter - origin2;

                Vector3? closestPoint = GetClosestPoint(origin1, dir1, origin2, dir2);

                if (closestPoint == null)
                {
                    Debug.Log("Null point");
                    cpCount++;
                    continue;
                }

                Vector3 normal = closestPoint.Value - ObjectCenter.transform.position;

                _intersections[i][cpCount].transform.position = closestPoint.Value;
                _intersections[i][cpCount].transform.localScale = Vector3.one * PrimitiveScaleSlider.value;
                _intersections[i][cpCount].transform.LookAt(0.5f * (origin1 + origin2), Vector3.forward);
                _intersections[i][cpCount].GetComponent<MeshRenderer>().material.color = pixelColor;

                float distanceFromCenter = Vector3.Distance(_intersections[i][cpCount].transform.position, ObjectCenter.transform.position);

                points.Add(PlyPoint.Create(closestPoint.Value, normal.normalized, pixelColor, distanceFromCenter));
                cpCount++;
            }

            totalCpCount += cpCount;
            Debug.Log($"Calculated {cpCount} common points between images {i} and {i + 1}");
        }

        Debug.Log($"Calculated {totalCpCount} common points in total");

        _currentPointCloud = points;
        ApplyCulling();
    }

    public static bool AreValuesInsideRectangle(int x, int y, int rectX1, int rectY1, int rectX2, int rectY2, int rectX3, int rectY3, int rectX4, int rectY4)
    {
        // Check if (x, y) is inside the rectangle defined by (rectX1, rectY1), (rectX2, rectY2), (rectX3, rectY3), (rectX4, rectY4)

        // Sort the rectangle's coordinates to find the minimum and maximum X and Y values
        int minX = Math.Min(rectX1, Math.Min(rectX2, Math.Min(rectX3, rectX4)));
        int minY = Math.Min(rectY1, Math.Min(rectY2, Math.Min(rectY3, rectY4)));
        int maxX = Math.Max(rectX1, Math.Max(rectX2, Math.Max(rectX3, rectX4)));
        int maxY = Math.Max(rectY1, Math.Max(rectY2, Math.Max(rectY3, rectY4)));

        // Check if (x, y) is outside the bounds of the rectangle
        if (x < minX || x > maxX || y < minY || y > maxY)
        {
            // (x, y) is outside the rectangle
            return true;
        }
        else
        {
            // (x, y) is inside the rectangle
            return false;
        }
    }

    private static Vector3? GetClosestPoint(Vector3 ray1origin, Vector3 ray1direction, Vector3 ray2origin, Vector3 ray2direction)
    {
        Vector3 p1 = ray1origin;
        Vector3 p2 = ray2origin;

        Vector3 d1 = ray1direction.normalized;
        Vector3 d2 = ray2direction.normalized;

        // Calculate the direction vector perpendicular to both ray directions
        Vector3 cross = Vector3.Cross(d1, d2);

        // If the cross product is very small, the rays are almost parallel
        if (cross.sqrMagnitude < 0.0001f)
        {
            // Handle parallel rays as needed (e.g., consider them as not intersecting)
            return null;
        }

        Vector3 w0 = p1 - p2;

        // Calculate parameters for the two rays
        float a = Vector3.Dot(d1, d1);
        float b = Vector3.Dot(d1, d2);
        float c = Vector3.Dot(d2, d2);
        float d = Vector3.Dot(d1, w0);
        float e = Vector3.Dot(d2, w0);

        // Calculate the intersection point
        float t1 = ((b * e) - (c * d)) / ((a * c) - (b * b));
        float t2 = ((a * e) - (b * d)) / ((a * c) - (b * b));

        Vector3 intersectionPoint1 = p1 + (t1 * d1);
        Vector3 intersectionPoint2 = p2 + (t2 * d2);

        return 0.5f * (intersectionPoint1 + intersectionPoint2);
    }

    public void GeneratePly()
    {
        List<PlyPoint> validPoints = _currentPointCloud.Where(x => x.DistanceFromCenter <= CullingDistanceSlider.value).ToList();

        string template = $"ply\r\nformat ascii 1.0\r\ncomment VCGLIB generated\r\nelement vertex {validPoints.Count}\r\nproperty float x\r\nproperty float y\r\nproperty float z\r\nproperty float nx\r\nproperty float ny\r\nproperty float nz\r\nproperty uchar red\r\nproperty uchar green\r\nproperty uchar blue\r\nelement face 0\r\nproperty list uchar int vertex_indices\r\nend_header\r\n";

        foreach (PlyPoint point in validPoints)
        {
            template += $"{point.Coordinate.x.ToString(CultureInfo.InvariantCulture)} {point.Coordinate.y.ToString(CultureInfo.InvariantCulture)} {point.Coordinate.z.ToString(CultureInfo.InvariantCulture)} ";
            template += $"{point.Normal.x.ToString(CultureInfo.InvariantCulture)} {point.Normal.y.ToString(CultureInfo.InvariantCulture)} {point.Normal.z.ToString(CultureInfo.InvariantCulture)} ";
            template += $"{(int)point.Color.x} {(int)point.Color.y} {(int)point.Color.z}\r\n";
        }

        string selectedApp = AvailableObjects.options[AvailableObjects.value].text;
        string filename = Path.Combine(DirectoryManager.TemporaryImages, selectedApp, "processed_images", "pointcloud.ply");

        File.WriteAllText(filename, template);
    }

    public void GenerateMesh()
    {
        GeneratePly();

        string selectedApp = AvailableObjects.options[AvailableObjects.value].text;
        string psrPath = Path.Combine(Application.streamingAssetsPath, "generate_mesh.py");

        ProcessStartInfo startInfo = new ProcessStartInfo(DirectoryManager.Python)
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"\"{psrPath}\" --appid {selectedApp}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true,
        };

        Process process = Process.Start(startInfo);
        process.WaitForExit();
    }
}
