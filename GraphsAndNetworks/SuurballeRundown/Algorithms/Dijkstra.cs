using SuurballeRundown.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuurballeRundown.Algorithms
{
    public class Dijkstra
    {
        private const int INF = 1000000;

        public Dijkstra()
        {
        }

        //public GraphPath ExecuteListVersion(int source, int destination)
        //{
        //    var q = _graph.Vertices.ToList();
        //    var s = new List<Vertex>();

        //    for (int i = 0; i < q.Count; i++)
        //    {
        //        q[i].ReachingCost = INF;
        //        q[i].Previous = null;
        //    }

        //    q[source].ReachingCost = 0;
        //    var currIndex = source;
        //    do
        //    {
        //        var minimum = INF;
        //        var smallestIndex = 0;
        //        foreach(var neighbour in q[currIndex].Neighbours)
        //        {
        //            if(minimum > neighbour.ReachingCost)
        //            {
        //                minimum = neighbour.ReachingCost;
        //                smallestIndex = neighbour.Index;
        //            }
        //        }


        //        s.Add(q[currIndex]);
        //        q.RemoveAt(currIndex);

        //        if (smallestIndex == destination)
        //            break;

        //        foreach (var neighbour in q[smallestIndex].Neighbours)
        //        {
        //            var newDist = q[smallestIndex].ReachingCost + neighbour.ReachingCost;
        //            if (neighbour.ReachingCost > newDist)
        //            {
        //                var index = _graph.GetVertexId(neighbour.Index);
        //                if (index != -1)
        //                {
        //                    q[index].ReachingCost = newDist;
        //                    q[index].Previous = q[smallestIndex];
        //                }
        //            }
        //        }
        //    }
        //    while (q.Count > 0);

        //    return new GraphPath(s);
        //}

        public GraphPath ExecuteArrayVersion(Graph graph, int source, int destination)
        {
            int graphSize = graph.AdjacencyTable.Count;
            int[] dist = new int[graphSize];
            int[] prev = new int[graphSize];
            int[] nodes = new int[graphSize];

            for (int i = 0; i < graphSize; i++)
            {
                dist[i] = prev[i] = INF;
                nodes[i] = i;
            }

            dist[source] = 0;
            do
            {
                int smallest = nodes[0];
                int smallestIndex = 0;
                for (int i = 1; i < graphSize; i++)
                {
                    if (dist[nodes[i]] < dist[smallest])
                    {
                        smallest = nodes[i];
                        smallestIndex = i;
                    }
                }
                graphSize--;
                nodes[smallestIndex] = nodes[graphSize];

                if (dist[smallest] == INF || smallest == destination)
                    break;

                for (int i = 0; i < graphSize; i++)
                {
                    int v = nodes[i];
                    int newDist = dist[smallest] + graph.AdjacencyTable[new Relation(smallest, v)];
                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        prev[v] = smallest;
                    }
                }
            } while (graphSize > 0);

            return ReconstructPath(prev, dist, source, destination);
        }

        public GraphPath ReconstructPath(int[] prev, int[] dist, int SRC, int DEST)
        {
            int[] ret = new int[prev.Length];
            int currentNode = 0;
            ret[currentNode] = DEST;
            while (ret[currentNode] != INF && ret[currentNode] != SRC)
            {
                ret[currentNode + 1] = prev[ret[currentNode]];
                currentNode++;
            }
            if (ret[currentNode] != SRC)
                return null;
            int[] reversed = new int[currentNode + 1];
            for (int i = currentNode; i >= 0; i--)
                reversed[currentNode - i] = ret[i];
            return new GraphPath(reversed, dist);
        }
    }
}
