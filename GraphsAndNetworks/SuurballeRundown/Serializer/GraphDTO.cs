using System.Collections.Generic;

namespace SuurballeRundown.Serializer
{
    public class GraphDTO
    {
        public List<VertexDTO> Vertices { get; set; }

        public int[][] AdjacencyTable { get; set; }
    }
}
