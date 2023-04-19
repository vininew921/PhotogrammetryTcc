using OpenTK.Mathematics;

namespace PhotogrammetryMath;

public static class NearestNeighbors
{
    public static List<Vector3> GetNearestNeighbors(Vector3 p, List<Vector3> possibleNeighbors, bool includeSelf = false, int n = 3)
    {
        if (n > possibleNeighbors.Count - (includeSelf ? 0 : 1))
        {
            n = possibleNeighbors.Count - (includeSelf ? 0 : 1);
        }

        List<Vector3> copy = new List<Vector3>();
        copy.AddRange(possibleNeighbors);

        List<Vector3> orderedNeighbors = copy.Where(x => x != p || includeSelf).OrderBy(y => Vector3.Distance(p, y)).ToList();

        return orderedNeighbors.GetRange(0, n);
    }
}
