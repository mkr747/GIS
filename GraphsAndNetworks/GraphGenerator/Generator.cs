using Models;
using Serializer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace GraphGenerator
{
    public class Generator
    {
        private readonly string  _pathToFile;
        private readonly IFileReader _fileReader;

        public Generator(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        
        public void Generate(int numberOfVertices, int edgePercentage, int maxEdgeWeight)
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

            int lastVertex = GraphConnectionChecker[random.Next(0, GraphConnectionChecker.Count - 1)];
            GraphConnectionChecker.Remove(lastVertex);
            int currentVertex;

            while (GraphConnectionChecker.Count >= 1)
            {
                currentVertex = GraphConnectionChecker[random.Next(0, GraphConnectionChecker.Count - 1)];
                edges.Add(new Tuple<int, int, int>(lastVertex, currentVertex, random.Next(1, maxEdgeWeight)));
                allEdges.RemoveAll(x => x.Item1 == lastVertex && x.Item2 == currentVertex);
                lastVertex = currentVertex;
                GraphConnectionChecker.Remove(currentVertex);
            }

            Tuple<int, int> edge;
            while (edges.Count < maxEdgesNumber)
            {
                edge = allEdges[random.Next(0, allEdges.Count)];
                edges.Add(new Tuple<int, int, int>(edge.Item1, edge.Item2, random.Next(1, maxEdgeWeight)));
                allEdges.Remove(edge);
            }
            bool flag = true;
            int currentFileNumber = 1;
            string fileName;
            string pathToFile;

            do
            {
                fileName = "Graph_" + numberOfVertices + "_" + edgePercentage + "_" + maxEdgeWeight + "_" + currentFileNumber;
                pathToFile = Path.Combine(Environment.CurrentDirectory, fileName);
                if (!File.Exists(_pathToFile + ".txt"))
                {
                    flag = false;
                }
                currentFileNumber++;
            }
            while (flag);

            Console.WriteLine("Saving generated graph to " + fileName);
            var output = SetGraph(numberOfVertices, edges);
            _fileReader.SaveToFile(output, pathToFile);
            
            //using (StreamWriter sw = File.CreateText(fileName + ".txt"))
            //{
            //    sw.WriteLine(numberOfVertices);
            //    foreach (Tuple<int, int, int> edge1 in edges)
            //    {
            //        sw.WriteLine("{0} {1} {2}", edge1.Item1, edge1.Item2, edge1.Item3);
            //    }
            //}

            //Console.WriteLine();
        }

        private GraphDTO SetGraph(int vertices, IList<Tuple<int, int, int>> edges)
        {
            var graph = new GraphDTO();
            var array = new int[vertices, vertices];
            foreach(var edge in edges)
            {
                array[edge.Item1, edge.Item2] = edge.Item3;
            }

            graph.AdjacencyTable = array;

            return graph;
        }
    }
}
