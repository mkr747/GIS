using Models.Models;

namespace GraphGenerator
{
    public interface IGenerator
    {
        Graph Generate(int numberOfVertices, int edgePercentage, int maxEdgeWeight);
    }
}