using Newtonsoft.Json;
using OpenTK.Mathematics;
using System.Diagnostics;

namespace PhotogrammetryMath;

public static class Calibration
{
    public static CameraMatrix? Calibrate(string id)
    {
        CheckCalibrationDirectory();

        //TO DO: Call python calibration program
        ProcessStartInfo startInfo = new ProcessStartInfo(Path.GetFullPath("./calibrator.exe"))
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"--images {Path.GetFullPath("./Images")} --appid {id}"
        };

        Process? process = Process.Start(startInfo);
        process?.WaitForExit();

        return JsonConvert.DeserializeObject<CameraMatrix>(File.ReadAllText($"./CalibrationResults/{id}.json"));
    }

    public static void CheckCalibrationDirectory()
    {
        if (!Directory.Exists("./CalibrationResults"))
        {
            Directory.CreateDirectory("./CalibrationResults");
        }
    }
}

public class CameraMatrix
{
    public float Fx { get; set; }
    public float Fy { get; set; }
    public float S { get; set; }
    public float X0 { get; set; }
    public float Y0 { get; set; }

    public CameraMatrix()
    { }

    public CameraMatrix(float fx, float fy, float s, float x0, float y0)
    {
        Fx = fx;
        Fy = fy;
        S = s;
        X0 = x0;
        Y0 = y0;
    }

    public Matrix3 ToMatrix() => new Matrix3(Fx, S, X0, 0, Fy, Y0, 0, 0, 1);
}
