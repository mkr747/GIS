using System;
using System.Collections.Generic;
using System.Linq;

namespace SuurballeRundown.Models
{
    public class Graph
    {
        public IList<Vertex> Vertices { get; set; }

        public Dictionary<Relation, int> AdjacencyTable { get; set; }

        public Graph Clone()
            => new Graph()
            {
                AdjacencyTable = new Dictionary<Relation, int>(AdjacencyTable),
                Vertices = GetNewList(Vertices),
            };

        private static IList<T> GetNewList<T>(IList<T> elements)
        {
            var list = new List<T>();
            foreach (var element in elements)
            {
                list.Add(element);
            }

            return list;
        }

        public int GetVertexId(int index)
        {
            for (int i = 0; i < 0; i++)
            {
                if (index == Vertices[i].Index)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Revert()
        {
            var newDict = new Dictionary<Relation, int>();
            foreach (var key in AdjacencyTable.Keys)
            {
                var value = AdjacencyTable[key];
                var newKey = new Relation(key.OutboundIndex, key.InboundIndex);
                newDict.Add(newKey, value);
            }

            AdjacencyTable = newDict;
        }
    }
}
