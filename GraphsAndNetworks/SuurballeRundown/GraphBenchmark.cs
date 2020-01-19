using BenchmarkDotNet.Attributes;
using GraphGenerator;
using Models.Models;
using Serializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public void PerformTest()
        {
            foreach (var graph in GetData())
            {
                _app.PerformTests(graph, graph.Vertices.First().Index, graph.Vertices.Last().Index);
            }
        }


        public IEnumerable<Graph> GetData()
        {
            foreach (var graph in _graphs)
            {
                yield return graph;
            }
        }

        private void SetUpTestGraphs()
        {
            _graphGenerator = new Generator(new GraphSerializer());
            _graphs = new List<Graph>();
            List<int> verticesNumberList = new List<int>() { 5, 10, 50, 100, 300, 600, 1000 };
            List<int> percentageList = new List<int>() { 40, 60, 80 };

            foreach (int verticesNumber in verticesNumberList)
            {
                foreach (int edgePercentage in percentageList)
                {

                    var maxWeight = 20;

                    string fileName = "Graph_" + verticesNumber + "_" + edgePercentage + "_" + maxWeight + "_1";
                    string pathToFile = Path.Combine(Path.GetDirectoryName(System.AppContext.BaseDirectory), "assets", fileName);
                    if (!File.Exists(pathToFile))
                    {
                        Console.WriteLine("Reading " + fileName + " from file");
                        _graphs.Add(_graphGenerator.ExternalSetGraph(File.ReadAllLines(pathToFile + ".txt")));
                        Console.WriteLine($"Number of verticies: {verticesNumber}");
                        Console.WriteLine($"Edge precentage: {edgePercentage}%");
                        Console.WriteLine($"Max weight: {maxWeight}");
                    }
                    else
                    {
                        throw new Exception();
                        //_graphs.Add(_graphGenerator.Generate(verticesNumber, edgePercentage, maxWeight));
                        //Console.WriteLine($"Number of verticies: {verticesNumber}");
                        //Console.WriteLine($"Edge precentage: {edgePercentage}%");
                        //Console.WriteLine($"Max weight: {maxWeight}");

                        //Console.WriteLine();
                    }
                }
            }
        }
    }
}
