using Newtonsoft.Json;
using OpenTK.Mathematics;
using System.Diagnostics;

namespace PhotogrammetryMath;

public static class Calibration
{
    private static readonly string _calibratorPath = "./opencv_calibrator.exe";
    private static readonly string _appData = Path.GetFullPath($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/PhotogrammetryTCC");
    private static readonly string _calibrationResultsPath = Path.GetFullPath($"{_appData}/CalibrationResults");

    public static CameraMatrix? Calibrate(string id, string imagesPath)
    {
        CheckCalibrationDirectory();

        ProcessStartInfo startInfo = new ProcessStartInfo(Path.GetFullPath(_calibratorPath))
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"--images {Path.GetFullPath(imagesPath)} --appid {id}"
        };

        Process? process = Process.Start(startInfo);
        process?.WaitForExit();

        return JsonConvert.DeserializeObject<CameraMatrix>(File.ReadAllText($"{_calibrationResultsPath}/{id}.json"));
    }

    public static void CheckCalibrationDirectory()
    {
        if (!Directory.Exists(_calibrationResultsPath))
        {
            Directory.CreateDirectory(_calibrationResultsPath);
        }
    }

    public static List<CameraMatrix> GetAvailableCalibrations()
    {
        List<CameraMatrix> calibrations = new List<CameraMatrix>();
        foreach (string file in Directory.GetFiles(Path.GetFullPath(_calibrationResultsPath)))
        {
            if (!file.Contains(".json"))
            {
                continue;
            }

            try
            {
                CameraMatrix? cameraMatrix = JsonConvert.DeserializeObject<CameraMatrix>(File.ReadAllText(file));
                if (cameraMatrix == null)
                {
                    continue;
                }

                calibrations.Add(cameraMatrix);
            }
            catch
            { }
        }

        return calibrations;
    }
}

public class CameraMatrix
{
    public float Fx { get; set; }
    public float Fy { get; set; }
    public float S { get; set; }
    public float X0 { get; set; }
    public float Y0 { get; set; }
    public string Id { get; set; } = default!;

    public CameraMatrix()
    { }

    public CameraMatrix(float fx, float fy, float s, float x0, float y0, string id)
    {
        Fx = fx;
        Fy = fy;
        S = s;
        X0 = x0;
        Y0 = y0;
        Id = id;
    }

    public Matrix3 ToMatrix() => new Matrix3(Fx, S, X0, 0, Fy, Y0, 0, 0, 1);

    public string ToMatrixString() => $"Focal Length X: {Fx}\nFocal Length Y: {Fy}\nOptical Center X: {X0}\nOptical Center Y: {Y0}\nSkew: {S}";

    public override string ToString() => Id;
}
