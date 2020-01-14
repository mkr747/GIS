using SuurballeRundown.Models;

namespace SuurballeRundown.Algorithms
{
    public class Suurballe
    {
        private readonly Dijkstra _dijkstra;
        private readonly Graph _graph;

        public Suurballe(Graph graph)
        {
            _dijkstra = new Dijkstra(graph);
            _graph = graph;
        }

        public void Execute(Vertex root)
        {
            foreach(var i in _graph.Vertices)
            {
                _dijkstra.FindPath(root, i);
            }
        }
    }
}
