using Models;
using Models.Models;
using System;
using System.Collections.Generic;

namespace Serializer.Interfaces
{
    public interface IGraphSerializer
    {
        Graph Serialize(int vertices, IList<Tuple<int, int, int>> edges);
    }
}