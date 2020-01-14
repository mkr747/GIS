namespace SuurballeRundown.Models
{
    public class Edge
    {
        private readonly Vertex _start;
        private readonly Vertex _end;

        public Edge(ref Vertex start, ref Vertex end)
        {
            _start = start;
            _end = end;
        }

        public Vertex GetStart() => _start;

        public Vertex GetEnd() => _end;
    }
}
