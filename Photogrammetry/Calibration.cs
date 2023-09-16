using Shared;
using System.Diagnostics;

namespace Photogrammetry;

public static class Calibration
{
    private static readonly string _calibratorPath = "./calibration.py";

    public static void Calibrate(string id)
    {
        DirectoryManager.SetupDirectories();

        ProcessStartInfo startInfo = new ProcessStartInfo(DirectoryManager.Python)
        {
            WindowStyle = ProcessWindowStyle.Hidden,
            Arguments = $"\"{Path.GetFullPath(_calibratorPath)}\" --images {DirectoryManager.TemporaryImages} --appid {id}",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        Process? process = Process.Start(startInfo);
        process?.WaitForExit();
    }

    public static List<string> GetAvailableCalibrations()
    {
        List<string> calibrations = new List<string>();

        foreach (string file in Directory.GetFiles(Path.GetFullPath(DirectoryManager.CalibrationResults)))
        {
            if (!file.Contains(".json"))
            {
                continue;
            }

            calibrations.Add(Path.GetFileNameWithoutExtension(file));
        }

        return calibrations;
    }
}
