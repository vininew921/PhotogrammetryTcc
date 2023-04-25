using Newtonsoft.Json;
using PhotogrammetryMath.Models;
using Shared;
using System.Diagnostics;

namespace PhotogrammetryMath;

public static class Calibration
{
    private static readonly string _calibratorPath = "./opencv_calibrator.exe";

    public static CameraMatrix? Calibrate(string id, string imagesPath)
    {
        DirectoryManager.SetupDirectories();

        ProcessStartInfo startInfo = new ProcessStartInfo(Path.GetFullPath(_calibratorPath))
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"--images {Path.GetFullPath(imagesPath)} --appid {id}"
        };

        Process? process = Process.Start(startInfo);
        process?.WaitForExit();

        return JsonConvert.DeserializeObject<CameraMatrix>(File.ReadAllText($"{DirectoryManager.CalibrationResults}/{id}.json"));
    }

    public static List<CameraMatrix> GetAvailableCalibrations()
    {
        List<CameraMatrix> calibrations = new List<CameraMatrix>();
        foreach (string file in Directory.GetFiles(Path.GetFullPath(DirectoryManager.CalibrationResults)))
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
