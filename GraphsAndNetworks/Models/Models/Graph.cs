using System.Collections.Generic;

namespace Models.Models
{
    public class Graph
    {
        public IList<Vertex> Vertices { get; set; }

        public IDictionary<Relation, int> AdjacencyTable { get; set; }
    }
}
