using Models;
using Models.Models;

namespace Serializer.Interfaces
{
    public interface IGraphSerializer
    {
        Graph Serialize(GraphDTO graph);
    }
}