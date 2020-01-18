using SuurballeRundown.Algorithms;
using SuurballeRundown.Models;
using SuurballeRundown.Serializer;
using System;

namespace SuurballeRundown
{
    public class StartUp
    {
        private readonly IFileReader _fileReader;
        private Suurballe _suurballeAlgorythm;
        private Graph _graph;

        public StartUp()
        {
            _fileReader = new FileReader("data.txt", "output.txt");
            _graph = GraphSerializer.Serialize(_fileReader.GetGraph());
            _suurballeAlgorythm = new Suurballe(new Dijkstra());
        }

        public void PerformTests()
        {
            var output = _suurballeAlgorythm.Execute(_graph, 0, 6);
            Console.WriteLine(output);
        }
    }
}
