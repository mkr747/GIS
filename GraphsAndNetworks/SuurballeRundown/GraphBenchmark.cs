using BenchmarkDotNet.Attributes;
using GraphGenerator;
using Models.Models;
using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuurballeRundown
{
    public class GraphBenchmark
    {
        private StartUp _app;
        private IList<Graph> _graphs;
        private IGenerator _graphGenerator;

        [GlobalSetup]
        public void SetUp()
        {
            _app = new StartUp();
            SetUpTestGraphs();
        }

        [Benchmark]
        public void PerformTest()
        {
            foreach(var graph in GetData())
            {
                _app.PerformTests(graph, graph.Vertices.First().Index, graph.Vertices.Last().Index);
            }
        }


        public IEnumerable<Graph> GetData()
        {
            foreach(var graph in _graphs)
            {
                yield return graph;
            }
        }

        private void SetUpTestGraphs()
        {
            var rnd = new Random();
            _graphGenerator = new Generator(new GraphSerializer());
            _graphs = new List<Graph>();
            for(int i = 0; i < 10; i++)
            {
                var numberOfVerticies = rnd.Next(5, 10);
                var precentage = 70;
                var maxWeight = rnd.Next(2, 30);
                _graphs.Add(_graphGenerator.Generate(numberOfVerticies, precentage, maxWeight));
                Console.WriteLine($"Number of verticies: {numberOfVerticies}");
                Console.WriteLine($"Edge precentage: {precentage}%");
                Console.WriteLine($"Max weight: {maxWeight}");
                foreach (var o  in _graphs[i].AdjacencyTable)
                {
                    Console.WriteLine($"Table: {o.Key.InboundIndex}, {o.Key.OutboundIndex} : {o.Value}");
                }

                Console.WriteLine();
            }
        }
    }
}
