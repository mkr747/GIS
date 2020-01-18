using Newtonsoft.Json;
using SuurballeRundown.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SuurballeRundown.Serializer
{
    public class FileReader : IFileReader
    {
        private readonly string _dataFile;
        private readonly string _outputFile;

        public FileReader(string storingDirectory)
        {
            _dataFile = $"{storingDirectory}\\input.txt";
            _outputFile = $"{storingDirectory}\\result.txt";
        }

        public FileReader(string input, string output)
        {
            var dir = Directory.GetCurrentDirectory();
            _dataFile = $"{dir}\\{input}";
            _outputFile = $"{dir}\\{output}";
        }

        public GraphDTO GetGraph() => JsonConvert.DeserializeObject<GraphDTO>(File.ReadAllText(_dataFile));

        public void SetGraph(GraphDTO graph) => File.WriteAllText(_dataFile, JsonConvert.SerializeObject(graph));

        public void SaveToFile(GraphPath path) => File.WriteAllText(_outputFile, JsonConvert.SerializeObject(path));

        public void SaveToFile(GraphDTO path) => File.WriteAllText(_outputFile, JsonConvert.SerializeObject(path));
    }
}
