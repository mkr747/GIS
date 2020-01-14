using System.Collections.Generic;
using System.Linq;

namespace SuurballeRundown.Models
{
    public class GraphPath
    {
        private Vertex _source;
        private Vertex _destination;

        public IEnumerable<Vertex> Vertices { get; set; }

        public IEnumerable<Edge> Edges { get; private set; }

        public GraphPath()
        {

        }

        public void AddEdge(int startId, int endId)
        {
            
        }
    }
}
