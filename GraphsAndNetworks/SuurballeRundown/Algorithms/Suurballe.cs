using BenchmarkDotNet.Attributes;
using Models;
using Models.Models;
using System;
using System.Linq;

namespace SuurballeRundown.Algorithms
{
    public class Suurballe : ISuurballe
    {
        private readonly IDijkstra _dijkstra;

        public Suurballe(IDijkstra dijkstra)
        {
            _dijkstra = dijkstra;
        }


        public GraphPath[] Execute(Graph graph, int source, int destination)
        {
            var first = _dijkstra.ExecuteListVersion(graph, source, destination);
            var newGraph = graph.Clone(first.Vertices
                    .Where(x => x.Index != source &&
                                x.Index != destination)
                    .ToList());

            Console.WriteLine(graph.GetCost(first));
            newGraph.Revert();
            
            var second = _dijkstra.ExecuteListVersion(newGraph, destination, source);
            Console.WriteLine(newGraph.GetCost(second));

            return new GraphPath[] { first, second };
        }
    }
}
