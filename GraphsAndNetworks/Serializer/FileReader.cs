using Models;
using Models.Models;
using Newtonsoft.Json;
using Serializer.Interfaces;
using System.IO;

namespace Serializer
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

        public void SaveToFile(GraphDTO graph, string write) => File.WriteAllText(write, JsonConvert.SerializeObject(graph));

        public void SaveToFile(GraphPath path) => File.WriteAllText(_outputFile, JsonConvert.SerializeObject(path));

        public void SaveToFile(GraphDTO graph) => File.WriteAllText(_outputFile, JsonConvert.SerializeObject(graph));
    }
}
