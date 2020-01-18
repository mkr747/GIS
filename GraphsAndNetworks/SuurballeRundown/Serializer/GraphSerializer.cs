using SuurballeRundown.Models;
using System.Collections.Generic;

namespace SuurballeRundown.Serializer
{
    public class GraphSerializer
    {
        public static Graph Serialize(GraphDTO graph)
        {
            var verticies = new List<Vertex>();
            foreach(var element in graph.Vertices)
            {
                verticies.Add(new Vertex{ Index = element });
            }

            var dictionary = new Dictionary<Relation, int>();
            var size = verticies.Count;
            for (int i = 0; i < size; i++)
            {
                for(int o = 0; o < size; o++)
                {
                    dictionary.Add(new Relation(i, o), graph.AdjacencyTable[i, o]);
                }
            }

            var outputGraph = new Graph
            {
                Vertices = verticies,
                AdjacencyTable = dictionary
            };

            return outputGraph;
        }
    }
}
