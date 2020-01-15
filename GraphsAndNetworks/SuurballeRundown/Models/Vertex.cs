using System.Collections.Generic;

namespace SuurballeRundown.Models
{
    public class Vertex
    {
        public int Index { get; set; }

        public int ReachingCost { get; set; }

        public Vertex Previous { get; set; }
    }
}
