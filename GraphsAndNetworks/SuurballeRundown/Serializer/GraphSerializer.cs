using SuurballeRundown.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SuurballeRundown.Serializer
{
    public class GraphSerializer
    {
        private readonly string _dataFile;
        private readonly string _outputFile;

        public GraphSerializer(string storingDirectory)
        {
            _dataFile = $"{storingDirectory}\\input";
            _outputFile = $"{storingDirectory}\\result";
        }

        public GraphSerializer(string input, string output)
        {
            _dataFile = input;
            _outputFile = output;
        }

        public GraphDTO GetGraph() => JsonSerializer.Deserialize<GraphDTO>(File.ReadAllText(_dataFile));

        public void SetGraph(GraphDTO graph) => File.WriteAllText(_dataFile, JsonSerializer.Serialize(graph));

        public void SaveToFile(IEnumerable<GraphPath> path) => File.WriteAllText(_outputFile, JsonSerializer.Serialize(path));
    }
}
