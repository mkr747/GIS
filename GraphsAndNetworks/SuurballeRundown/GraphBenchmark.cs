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
                _graphs.Add(_graphGenerator.Generate(rnd.Next(5, 10), 70, rnd.Next(2, 30)));
            }
        }
    }
}
