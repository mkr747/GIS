using SuurballeRundown.Models;
using System;
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
                AdjacencyTable = graph.GetOmmitingCopyDictionary(ommit),
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

        public static int GetCost(this Graph graph, GraphPath path)
        {
            var sum = 0;
            for (int i = 1; i < path.Vertices.Count; i++)
            {
                var key = graph.AdjacencyTable.GetRelation(path.Vertices[i-1].Index, path.Vertices[i].Index);
                sum += graph.AdjacencyTable[key];
            }

            return sum;
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

        public static Relation GetRelation<T>(this IDictionary<Relation, T> dictionary, int inboundIndex, int outboundIndex)
        {
            foreach(var key in dictionary.Keys)
            {
                if(key.InboundIndex == inboundIndex && key.OutboundIndex == outboundIndex)
                {
                    return key;
                }
            }

            throw new Exception("There is no such Relation");
        }

        public static Dictionary<Relation, int> GetOmmitingCopyDictionary(this Graph graph, IList<Vertex> ommit)
        {
            var dict = new Dictionary<Relation, int>();
            foreach(var key in graph.AdjacencyTable.Keys)
            {
                if (!ommit.Contains(key.InboundIndex) && !ommit.Contains(key.OutboundIndex))
                {
                    dict.Add(key, graph.AdjacencyTable[key]);
                }
            }

            return dict;
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
