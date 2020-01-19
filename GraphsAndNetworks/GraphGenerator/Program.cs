using Serializer;

namespace GraphGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var generator = new Generator(new FileReader("output"));
            var generator = new Generator(new GraphSerializer());
            generator.Generate(10,5,12);
            
        }
    }
}
