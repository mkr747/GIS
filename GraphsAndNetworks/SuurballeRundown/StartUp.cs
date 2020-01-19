using BenchmarkDotNet.Attributes;
using Models.Models;
using Serializer;
using Serializer.Interfaces;
using SuurballeRundown.Algorithms;
using System;

namespace SuurballeRundown
{
    public class StartUp
    {
        //private readonly IFileReader _fileReader;
        //private readonly IGraphSerializer _graphSerializer;
        private readonly Suurballe _suurballeAlgorythm;
        //private Graph _graph;

        public StartUp()
        {
            //_fileReader = new FileReader("data.txt", "output.txt");
            //_graphSerializer = new GraphSerializer();
            //_graph = _graphSerializer.Serialize(_fileReader.GetGraph());
            _suurballeAlgorythm = new Suurballe(new Dijkstra());
        }


        public void PerformTests(Graph graph, int source, int destination)
        {
            var output = _suurballeAlgorythm.Execute(graph, source, destination);
            foreach(var i in graph.AdjacencyTable)
            {
                Console.WriteLine($"Table: {i.Key.InboundIndex}, {i.Key.OutboundIndex} : {i.Value}");
            }

            foreach(var i in output[0].Vertices)
            {
                Console.WriteLine($"First:{i.Index}\n");
            }

            foreach (var i in output[1].Vertices)
            {
                Console.WriteLine($"Second:{i.Index}\n");
            }
        }
    }
}
