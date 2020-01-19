using BenchmarkDotNet.Running;
using SuurballeRundown.Algorithms;

namespace SuurballeRundown
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<GraphBenchmark>();
            var a = new GraphBenchmark();
            a.SetUp();
            a.PerformTest();
        }
    } 
}
