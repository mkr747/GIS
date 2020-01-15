using System.Collections.Generic;

namespace SuurballeRundown.Models
{
    public class Vertex
    {
        public int Index { get; set; }

        public IEnumerable<Vertex> Neighbours { get; set; } //Destination vertex's with reachingCost = edge cost

        public int ReachingCost { get; set; }

        public Vertex Previous { get; set; }
    }
}
