using SuurballeRundown.Models;
using System.Collections.Generic;

namespace SuurballeRundown
{
    public static class Extensions
    {
        public static bool Contains(this IList<Vertex> vertices, int compare)
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Index == compare)
                    return true;
            }

            return false;
        }

        public static Vertex GetVertex(this IList<Vertex> vertices, int id)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Index == id)
                    return vertices[i];
            }

            return null;
        }

        public static Graph Clone(this Graph graph, IList<Vertex> ommit = null)
        {
            var graphClone = new Graph()
            {
                AdjacencyTable = new Dictionary<Relation, int>(graph.AdjacencyTable),
                Vertices = graph.GetOmmitingCopyVerticies(ommit),
            };

            return graphClone;
        }

        public static void Revert(this Graph graph)
        {
            var newDict = new Dictionary<Relation, int>();
            foreach (var key in graph.AdjacencyTable.Keys)
            {
                var value = graph.AdjacencyTable[key];
                var newKey = new Relation(key.OutboundIndex, key.InboundIndex);
                newDict.Add(newKey, value);
            }

            graph.AdjacencyTable = newDict;
        }

        public static IList<Vertex> GetNeighbours(this Graph graph, Vertex root)
        {
            var output = new List<Vertex>();
            foreach (var key in graph.AdjacencyTable.Keys)
            {
                if (key.InboundIndex == root.Index)
                {
                    if (graph.AdjacencyTable[key] != 0)
                    {
                        output.Add(new Vertex
                        {
                            Index = key.OutboundIndex,
                            ReachingCost = graph.AdjacencyTable[key]
                        });
                    }
                }
            }

            return output;
        }

        public static int GetVertexId(this Graph graph, int index)
        {
            for (int i = 0; i < 0; i++)
            {
                if (index == graph.Vertices[i].Index)
                {
                    return i;
                }
            }

            return -1;
        }

        private static IList<Vertex> GetOmmitingCopyVerticies(this Graph graph, IList<Vertex> ommit)
        {
            var list = new List<Vertex>();
            foreach (var element in graph.Vertices)
            {
                if (!ommit.Contains(element.Index))
                {
                    list.Add(element);
                }
            }

            return list;
        }
    }
}
