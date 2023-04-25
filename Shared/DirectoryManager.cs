namespace Shared;

public static class DirectoryManager
{
    public static string AppData { get; } = Path.GetFullPath($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/PhotogrammetryTCC");
    public static string CalibrationResults { get; } = Path.GetFullPath($"{AppData}/CalibrationResults");

    public static string TriangulationResults { get; } = Path.GetFullPath($"{AppData}/TriangulationResults");

    public static string TemporaryImages { get; } = Path.GetFullPath($"{AppData}/TempImages");

    public static void SetupDirectories()
    {
        foreach (string dir in new string[] { AppData, CalibrationResults, TriangulationResults, TemporaryImages })
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
