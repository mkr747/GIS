using Models;
using Models.Models;
using Serializer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace GraphGenerator
{
    public class Generator : IGenerator
    {
        //private readonly string  _pathToFile;
        //private readonly IFileReader _fileReader;
        private readonly IGraphSerializer _graphSerializer;

        public Generator(IGraphSerializer graphSerializer)
        {
            //_fileReader = fileReader;
            _graphSerializer = graphSerializer;
        }

        public Graph Generate(int numberOfVertices, int edgePercentage, int maxEdgeWeight)
        {
            List<int> Vertices = new List<int>();
            List<int> GraphConnectionChecker = new List<int>();
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
            int counter = 0;
            Random random = new Random();

            while (counter < numberOfVertices)
            {
                Vertices.Add(counter);
                GraphConnectionChecker.Add(counter);
                counter++;
            }

            int maxEdgesNumber = (numberOfVertices * (numberOfVertices - 1)) * edgePercentage / 100;

            List<Tuple<int, int>> allEdges = new List<Tuple<int, int>>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < Vertices.Count; j++)
                {
                    if (i != j)
                    {
                        allEdges.Add(new Tuple<int, int>(i, j));
                    }
                }
            }


            //int lastVertex = GraphConnectionChecker[random.Next(0, GraphConnectionChecker.Count - 1)];
            //GraphConnectionChecker.Remove(lastVertex);
            //int currentVertex;

            //while (GraphConnectionChecker.Count >= 1)
            //{
            //    currentVertex = GraphConnectionChecker[random.Next(0, GraphConnectionChecker.Count - 1)];
            //    edges.Add(new Tuple<int, int, int>(lastVertex, currentVertex, random.Next(1, maxEdgeWeight)));
            //    allEdges.RemoveAll(x => x.Item1 == lastVertex && x.Item2 == currentVertex);
            //    lastVertex = currentVertex;
            //    GraphConnectionChecker.Remove(currentVertex);
            //}

            Console.WriteLine("Generating two disjoint paths");


            List<Tuple<int, int, int>> firstPath = new List<Tuple<int, int,int>>();
            List<Tuple<int, int, int>> secondPath = new List<Tuple<int, int,int>>();

            int lastVertex = GraphConnectionChecker[GraphConnectionChecker.Count - 1];
            GraphConnectionChecker.Remove(lastVertex);
            GraphConnectionChecker.RemoveAt(0);

            int firstPathLastVertex = 0;
            int secondPathLastVertex = 0;


            foreach(int vertex in GraphConnectionChecker)
            {
                if(random.Next(0,2) > 0)
                {
                    firstPath.Add(new Tuple<int, int, int>(firstPathLastVertex, vertex, random.Next(1, maxEdgeWeight)));
                    allEdges.RemoveAll(x => x.Item1 == firstPathLastVertex && x.Item2 == vertex);
                    firstPathLastVertex = vertex;
                }
                else
                {
                    secondPath.Add(new Tuple<int, int, int>(secondPathLastVertex, vertex, random.Next(1, maxEdgeWeight)));
                    allEdges.RemoveAll(x => x.Item1 == secondPathLastVertex && x.Item2 == vertex);
                    secondPathLastVertex = vertex;
                }
            }

            firstPath.Add(new Tuple<int, int, int>(firstPathLastVertex, lastVertex, random.Next(1, maxEdgeWeight)));
            secondPath.Add(new Tuple<int, int, int>(secondPathLastVertex, lastVertex, random.Next(1, maxEdgeWeight)));
            allEdges.RemoveAll(x => x.Item1 == firstPathLastVertex && x.Item2 == lastVertex);
            allEdges.RemoveAll(x => x.Item1 == secondPathLastVertex && x.Item2 == lastVertex);

            edges.AddRange(firstPath);
            edges.AddRange(firstPath);

            Console.WriteLine("Generating random edges");

            Tuple<int, int> edge;
            int edgePos;
            while (edges.Count < maxEdgesNumber)
            {
                edgePos = random.Next(0, allEdges.Count);
                edge = allEdges[edgePos];
                edges.Add(new Tuple<int, int, int>(edge.Item1, edge.Item2, random.Next(1, maxEdgeWeight)));
                allEdges.RemoveAt(edgePos);
            }

            bool flag = true;
            int currentFileNumber = 1;
            string fileName;
            string pathToFile;

            do
            {
                fileName = "Graph_" + numberOfVertices + "_" + edgePercentage + "_" + maxEdgeWeight + "_" + currentFileNumber;
                pathToFile = Path.Combine(Environment.CurrentDirectory, fileName);
                if (!File.Exists(pathToFile + ".txt"))
                {
                    flag = false;
                }
                currentFileNumber++;
            }
            while (flag);

            Console.WriteLine("Saving generated graph to " + fileName);

            using (StreamWriter sw = File.CreateText(fileName + ".txt"))
            {
                sw.WriteLine(numberOfVertices);
                foreach (Tuple<int, int, int> edge1 in edges)
                {
                    sw.WriteLine("{0} {1} {2}", edge1.Item1, edge1.Item2, edge1.Item3);
                }
            }

            var output = SetGraph(numberOfVertices, edges);
            return _graphSerializer.Serialize(output);
        }

        private GraphDTO SetGraph(int vertices, IList<Tuple<int, int, int>> edges)
        {
            var graph = new GraphDTO();
            var array = new int[vertices, vertices];
            foreach (var edge in edges)
            {
                array[edge.Item1, edge.Item2] = edge.Item3;
            }

            graph.Verticies = vertices;
            graph.AdjacencyTable = array;

            return graph;
        }

        public Graph ExternalSetGraph(IList<string> fileLines)
        {
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
            int vertices = Int32.Parse(fileLines[0]);
            for (int i=1; i<fileLines.Count; i++)
            {
                string[] numbers = fileLines[i].Split(' ');
                edges.Add(new Tuple<int, int, int>(Int32.Parse(numbers[0]), Int32.Parse(numbers[1]), Int32.Parse(numbers[2])));
            }

            return _graphSerializer.Serialize(SetGraph(vertices, edges));
        }
    }
}
