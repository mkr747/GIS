using System.Collections.Generic;
using SuurballeRundown.Models;

namespace SuurballeRundown.Serializer
{
    public interface IFileReader
    {
        GraphDTO GetGraph();
        void SaveToFile(GraphPath path);

        void SaveToFile(GraphDTO path);

        void SetGraph(GraphDTO graph);
    }
}