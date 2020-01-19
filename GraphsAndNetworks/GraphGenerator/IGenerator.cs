using Models;
using Models.Models;
using System.Collections.Generic;

namespace GraphGenerator
{
    public interface IGenerator
    {
        Graph Generate(int numberOfVertices, int edgePercentage, int maxEdgeWeight);
        Graph ExternalSetGraph(IList<string> fileLines);
    }
}