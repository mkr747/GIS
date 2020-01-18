using SuurballeRundown.Models;

namespace SuurballeRundown.Algorithms
{
    public class Suurballe : ISuurballe
    {
        private readonly IDijkstra _dijkstra;

        public Suurballe(IDijkstra dijkstra)
        {
            _dijkstra = dijkstra;
        }

        public GraphPath[] Execute(Graph graph, int source, int destination)
        {
            var first = _dijkstra.ExecuteListVersion(graph, source, destination);
            var newGraph = graph.Clone(first.Vertices);

            newGraph.Revert();
            var second = _dijkstra.ExecuteListVersion(newGraph, destination, source);

            return new GraphPath[] { first, second };
        }
    }
}
