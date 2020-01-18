using SuurballeRundown.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuurballeRundown.Algorithms
{
    public class Dijkstra : IDijkstra
    {
        private const int INF = 1000000;

        public Dijkstra()
        {
        }

        public GraphPath ExecuteListVersion(Graph graph, int source, int destination)
        {
            var q = graph.Vertices.ToList();
            var s = new List<Vertex>();

            for (int i = 0; i < q.Count; i++)
            {
                q[i].ReachingCost = INF;
                q[i].Previous = null;
            }

            q.GetVertex(source).ReachingCost = 0;
            var currIndex = source;
            do
            {
                var minimum = INF;
                var smallestIndex = 0;
                foreach (var neighbour in graph.GetNeighbours(q.GetVertex(currIndex)))
                {
                    if (minimum > neighbour.ReachingCost)
                    {
                        minimum = neighbour.ReachingCost;
                        smallestIndex = neighbour.Index;
                    }
                }


                var get = q.GetVertex(currIndex);
                s.Add(get);
                q.Remove(get);


                if (smallestIndex == destination)
                {
                    var small = q.GetVertex(smallestIndex);
                    s.Add(small);
                    q.Remove(small);
                    break;
                }

                currIndex = smallestIndex;
                foreach (var neighbour in graph.GetNeighbours(q.GetVertex(currIndex)))
                {
                    var newDist = q.GetVertex(smallestIndex).ReachingCost + neighbour.ReachingCost;
                    if (neighbour.ReachingCost > newDist)
                    {
                        var index = graph.GetVertexId(neighbour.Index);
                        if (index != -1)
                        {
                            q.GetVertex(index).ReachingCost = newDist;
                            q.GetVertex(index).Previous = q.GetVertex(smallestIndex);
                        }
                    }
                }
            }
            while (q.Count > 0);

            return new GraphPath(s);
        }

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
