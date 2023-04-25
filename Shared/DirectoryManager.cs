namespace Shared;

public static class DirectoryManager
{
    public static string AppData { get; } = Path.GetFullPath($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/PhotogrammetryTCC");
    public static string CalibrationResults { get; } = Path.GetFullPath($"{AppData}/CalibrationResults");

    public static string TriangulationResults { get; } = Path.GetFullPath($"{AppData}/TriangulationResults");

    public static void SetupDirectories()
    {
        if (!Directory.Exists(AppData))
        {
            Directory.CreateDirectory(AppData);
        }

        if (!Directory.Exists(CalibrationResults))
        {
            Directory.CreateDirectory(CalibrationResults);
        }

        if (!Directory.Exists(TriangulationResults))
        {
            Directory.CreateDirectory(TriangulationResults);
        }
    }
}
