using System.Collections.Generic;
using System.Linq;

namespace Models.Models
{
    public class GraphPath
    {
        public IList<Vertex> Vertices { get; set; }

        public GraphPath()
        {

        }

        public GraphPath(IList<Vertex> vertices)
        {
            Vertices = vertices;
        }

        public GraphPath(Vertex[] vertices)
        {
            Vertices = vertices.ToList();
        }

        public GraphPath(int[] verticiesId, int[] verticesCost)
        {
            Vertices = new List<Vertex>();
            for(int i = 0; i < verticiesId.Length; i++)
            {
                var previous = Vertices.Count > 0 ? Vertices.Last() : null;
                var vertex = new Vertex()
                {
                    Index = verticiesId[i],
                    ReachingCost = verticesCost[verticiesId[i]],
                    Previous = previous,
                };

                Vertices.Add(vertex);
            }
        }
    }
}
