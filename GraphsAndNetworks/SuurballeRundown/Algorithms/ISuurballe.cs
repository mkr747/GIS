using SuurballeRundown.Models;

namespace SuurballeRundown.Algorithms
{
    public interface ISuurballe
    {
        GraphPath[] Execute(Graph graph, int source, int destination);
    }
}