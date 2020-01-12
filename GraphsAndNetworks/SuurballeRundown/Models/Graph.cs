using System.Collections.Generic;

namespace SuurballeRundown.Models
{
    public class Graph
    {
        public IEnumerable<Vertex> Vertices { get; set; }

        public Dictionary<Relation, int> AdjacencyTable { get; set; }
    }
}
