using Models;
using Models.Models;
using Serializer.Interfaces;
using System.Collections.Generic;

namespace Serializer
{
    public class GraphSerializer : IGraphSerializer
    {
        public GraphSerializer()
        {

        }

        public Graph Serialize(GraphDTO graph)
        {
            var verticies = new List<Vertex>();
            for (int i = 0; i < graph.Verticies; i++)
            {
                verticies.Add(new Vertex { Index = i });
            }

            var dictionary = new Dictionary<Relation, int>();
            var size = verticies.Count;
            for (int i = 0; i < size; i++)
            {
                for (int o = 0; o < size; o++)
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
