using Serializer;
using System;
using System.IO;

namespace GraphGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator(new FileReader("output"));
            generator.Generate(10,5,12);
            
        }
    }
}
