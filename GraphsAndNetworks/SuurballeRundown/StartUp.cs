using Models.Models;
using Serializer;
using Serializer.Interfaces;
using SuurballeRundown.Algorithms;
using System;

namespace SuurballeRundown
{
    public class StartUp
    {
        private readonly IFileReader _fileReader;
        private readonly IGraphSerializer _graphSerializer;
        private readonly Suurballe _suurballeAlgorythm;
        private Graph _graph;

        public StartUp()
        {
            _fileReader = new FileReader("data.txt", "output.txt");
            _graphSerializer = new GraphSerializer();
            _graph = _graphSerializer.Serialize(_fileReader.GetGraph());
            _suurballeAlgorythm = new Suurballe(new Dijkstra());
        }

        public void PerformTests()
        {
            var output = _suurballeAlgorythm.Execute(_graph, 0, 6);
            Console.WriteLine(output);
        }
    }
}
