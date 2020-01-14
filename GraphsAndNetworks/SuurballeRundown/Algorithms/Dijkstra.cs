using SuurballeRundown.Models;

namespace SuurballeRundown.Algorithms
{
    public class Dijkstra
    {
        private const int INF = 1000000;
        private readonly Graph _graph;

        public Dijkstra(Graph graph)
        {
            _graph = graph;
        }

        public int[] FindPath(Vertex source, Vertex destination)
        {
            int graphSize = _graph.AdjacencyTable.Count;
            int[] dist = new int[graphSize];
            int[] prev = new int[graphSize];
            int[] nodes = new int[graphSize];

            for (int i = 0; i < graphSize; i++)
            {
                dist[i] = prev[i] = INF;
                nodes[i] = i;
            }

            dist[source.Index] = 0;
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

                if (dist[smallest] == INF || smallest == destination.Index)
                    break;

                for (int i = 0; i < graphSize; i++)
                {
                    int v = nodes[i];
                    int newDist = dist[smallest] + _graph.AdjacencyTable[new Relation(smallest, v)];
                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        prev[v] = smallest;
                    }
                }
            } while (graphSize > 0);

            return ReconstructPath(prev, source.Index, destination.Index);
        }

        public int[] ReconstructPath(int[] prev, int SRC, int DEST)
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
            return reversed;
        }
    }
}
