using SuurballeRundown.Models;

namespace SuurballeRundown.Algorithms
{
    public class Suurballe
    {
        private readonly Dijkstra _dijkstra;
        private readonly Graph _graph;

        public Suurballe(Graph graph)
        {
            _dijkstra = new Dijkstra();
            _graph = graph;
        }

        public void Execute(int source, int destination)
        {
            var first = _dijkstra.ExecuteArrayVersion(_graph, source, destination);
            var graph = _graph.Clone(first.Vertices);

            graph.Revert();
            var second = _dijkstra.ExecuteArrayVersion(graph, destination, source);
        }
    }
}
