using Models;
using Models.Models;

namespace Serializer.Interfaces
{
    public interface IFileReader
    {
        GraphDTO GetGraph();

        void SaveToFile(GraphPath path);

        void SaveToFile(GraphDTO graph, string write);

        void SaveToFile(GraphDTO graph);
    }
}