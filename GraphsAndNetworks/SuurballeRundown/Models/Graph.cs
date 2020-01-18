using System.Collections.Generic;

namespace SuurballeRundown.Models
{
    public class Graph
    {
        public IList<Vertex> Vertices { get; set; }

        public IDictionary<Relation, int> AdjacencyTable { get; set; }
    }
}
