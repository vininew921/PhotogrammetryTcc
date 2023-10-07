using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Triangulation : MonoBehaviour
{
    private List<GameObject>[] _intersections;

    [Header("Projection Settings")]
    public GameObject ObjectCenter;

    public GameObject LineIntersection;
    public ImageProjection projectionPrefab;
    public ImageProjection[] Projections;
    public List<CommonPoint> CommonPoints = new List<CommonPoint>();

    [Range(0.005f, 0.1f)]
    public float PrimitiveScale = 0.008f;

    public float ProjectionCenterDistance = 2.8f;
    public float ProjectionDistance = 26.5f;
    public float ProjectionScale = -0.7f;

    [Header("Marching Cubes")]
    public int GridSize = 32;

    public float CellSize = 0.1f;
    public bool SmoothNormals = false;
    public bool DrawNormals = false;
    public Material MeshMaterial;

    private void Start()
    {
        string appId = "maco-72";
        string workingDir = Path.Combine(DirectoryManager.TemporaryImages, appId, "processed_images");

        int imageCount = Directory.GetFiles(workingDir).Where(x => Path.GetExtension(x) == ".png").Count();

        Projections = new ImageProjection[imageCount];

        for (int i = 0; i < imageCount; i++)
        {
            ImageProjection imageProjection = Instantiate(projectionPrefab)
                                              .Load(Path.Combine(workingDir, $"{i}.png"), i * (360 / imageCount), ObjectCenter.transform.position);

            imageProjection.gameObject.SetActive(false);
            Projections[i] = imageProjection;
        }

        CommonPoints = JsonConvert.DeserializeObject<List<CommonPoint>>(File.ReadAllText(Path.Combine(workingDir, "common_keypoints.json")));
        Debug.Log("appId -> " + CommonPoints.Count);

        //System.Drawing.Rectangle[] rects = new System.Drawing.Rectangle[]
        //{
        //    new System.Drawing.Rectangle(0, 0, 1200, 270),
        //    new System.Drawing.Rectangle(0, 0, 200, 1200),
        //    new System.Drawing.Rectangle(800, 0, 1200, 1200),
        //    new System.Drawing.Rectangle(0, 750, 1200, 1200),
        //};

        //CommonPoints = CommonPoints.Where(x =>
        //{
        //    for (int i = 0; i < rects.Length; i++)
        //    {
        //        int ax = Mathf.FloorToInt(x.Coordinates.Ax);
        //        int ay = Mathf.FloorToInt(x.Coordinates.Ay);
        //        int bx = Mathf.FloorToInt(x.Coordinates.Bx);
        //        int by = Mathf.FloorToInt(x.Coordinates.By);

        //        if (rects[i].Contains(ax, ay) || rects[i].Contains(bx, by))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}).ToList();

        _intersections = new List<GameObject>[imageCount];

        for (int i = 0; i < _intersections.Length; i++)
        {
            _intersections[i] = new List<GameObject>();
            for (int j = 0; j < CommonPoints.Where(x => x.ImageA == i).Count(); j++)
            {
                _intersections[i].Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
                _intersections[i][j].SetActive(false);
            }
        }
    }

    private void Update()
    {
        List<Vector3> pointCloud = Triangulate();

        if (pointCloud.Count < 3)
        {
            Debug.LogError("Point cloud must have at least 3 points to create a mesh.");
            return;
        }
    }

    public List<Vector3> Triangulate()
    {
        int totalCpCount = 0;

        List<Vector3> points = new();

        for (int i = 0; i < Projections.Length - 1; i++)
        {
            //Projections[i].transform.RotateAround(ObjectCenter.transform.position, Vector3.up, 0.01f);
            Projections[i].UpdatePosition(ProjectionScale, ProjectionDistance, ProjectionCenterDistance);
            Projections[i + 1].UpdatePosition(ProjectionScale, ProjectionDistance, ProjectionCenterDistance);

            int cpCount = 0;
            foreach (CommonPoint cp in CommonPoints.Where(x => x.ImageA == i))
            {
                Color pixelColorA = Projections[i].GetPixelColor(cp.Coordinates.Ax, cp.Coordinates.Ay);
                Color pixelColorB = Projections[i + 1].GetPixelColor(cp.Coordinates.Ax, cp.Coordinates.Ay);
                Color pixelColor = 0.5f * (pixelColorA + pixelColorB);

                Vector3 origin1 = Projections[i].GetPixelPosition(cp.Coordinates.Ax, cp.Coordinates.Ay);
                Vector3 origin2 = Projections[i + 1].GetPixelPosition(cp.Coordinates.Bx, cp.Coordinates.By);

                Vector3 dir1 = Projections[i].ProjectionCenter - origin1;
                Vector3 dir2 = Projections[i + 1].ProjectionCenter - origin2;

                Vector3? closestPoint = GetClosestPoint(origin1, dir1, origin2, dir2);

                if (closestPoint == null)
                {
                    Debug.Log("Null point");
                    cpCount++;
                    continue;
                }

                points.Add(closestPoint.Value);

                _intersections[i][cpCount].SetActive(true);
                _intersections[i][cpCount].transform.position = closestPoint.Value;
                _intersections[i][cpCount].transform.localScale = Vector3.one * PrimitiveScale;
                _intersections[i][cpCount].transform.LookAt(0.5f * (origin1 + origin2), Vector3.forward);
                _intersections[i][cpCount].GetComponent<MeshRenderer>().material.color = pixelColor;

                cpCount++;
            }

            totalCpCount += cpCount;
            Debug.Log($"Calculated {cpCount} common points between images {i} and {i + 1}");
        }

        Debug.Log($"Calculated {totalCpCount} common points in total");

        return points;
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
}

public class CommonPoint
{
    [JsonProperty("image_a")]
    public int ImageA { get; set; }

    [JsonProperty("image_b")]
    public int ImageB { get; set; }

    public Coordinate Coordinates { get; set; }
}

public class Coordinate
{
    public float Ax { get; set; }
    public float Ay { get; set; }
    public float Bx { get; set; }
    public float By { get; set; }
}
