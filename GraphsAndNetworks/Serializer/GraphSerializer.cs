using Models;
using Models.Models;
using Serializer.Interfaces;
using System;
using System.Collections.Generic;

namespace Serializer
{
    public class GraphSerializer : IGraphSerializer
    {
        public GraphSerializer()
        {

        }

        public Graph Serialize(int vertices, IList<Tuple<int, int, int>> edges)
        {
            var verticies = new List<Vertex>();
            for (int i = 0; i < vertices; i++)
            {
                verticies.Add(new Vertex { Index = i });
            }

            var dictionary = new Dictionary<Relation, int>();
            foreach (var edge in edges)
            { 
                dictionary.Add(new Relation(edge.Item1, edge.Item2), edge.Item3);
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
