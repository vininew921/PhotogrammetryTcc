using Engine;
using Engine.Entities;
using Newtonsoft.Json;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using PhotogrammetryMath;

namespace Renderer;

internal class Application : EngineApplication
{
    private readonly string[] _args;
    private static readonly string _appData = Path.GetFullPath($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/PhotogrammetryTCC");
    private static readonly string _triangulationResults = Path.GetFullPath($"{_appData}/TriangulationResults");

    public Application(string[] args, int windowWidth = 800, int windowHeight = 600, string windowTitle = "Renderer") : base(windowWidth, windowHeight, windowTitle)
    {
        //TO DO: Args will contain vertex points to be rendered, add them to scene
        _args = args;
    }

    public override void OnLoad()
    {
        List<Vector3>? resultFromFile = JsonConvert.DeserializeObject<List<Vector3>>(File.ReadAllText(Path.Combine(_triangulationResults, "teste.json")));
        if (resultFromFile != null)
        {
            foreach (Vector3 point in resultFromFile)
            {
                AddMesh(new Cube(point, 10));
                List<Vector3> neighbors = NearestNeighbors.GetNearestNeighbors(point, resultFromFile, false, 6);

                foreach (Vector3 neighbor in neighbors)
                {
                    AddMesh(new Line(point, neighbor));
                }
            }
        }

        base.OnLoad();
    }

    public override void OnUpdate(FrameEventArgs e) => base.OnUpdate(e);
}
