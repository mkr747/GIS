using System.Collections.Generic;

namespace SuurballeRundown.Serializer
{
    public class GraphDTO
    {
        public int[] Vertices { get; set; }

        public int[,] AdjacencyTable { get; set; }

        public GraphDTO()
        {
        }
    }
}
