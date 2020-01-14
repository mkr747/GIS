using SuurballeRundown.Models;
using System;

namespace SuurballeRundown
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var v = new Vertex();
            var v2 = new Vertex();
            v.Index = 2;
            v2.Index = 3;
            var e = new Edge(ref v, ref v2);
            v.Index = 5;
            v2.Index = 6;
            Console.WriteLine(e.GetStart());
        }
    } 
}
