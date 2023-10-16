using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class PlyPoint
    {
        public Vector3 Coordinate { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 Color { get; set; }

        public static PlyPoint Create(Vector3 coordinate, Vector3 normal, Color color) => new PlyPoint
        {
            Coordinate = coordinate,
            Normal = normal,
            Color = new Vector3(color.r * 255, color.g * 255, color.b * 255)
        };
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
}
