using SuurballeRundown.Models;

namespace SuurballeRundown.Algorithms
{
    public interface IDijkstra
    {
        GraphPath ExecuteArrayVersion(Graph graph, int source, int destination);
        GraphPath ExecuteListVersion(Graph graph, int source, int destination);
        GraphPath ReconstructPath(int[] prev, int[] dist, int SRC, int DEST);
    }
}