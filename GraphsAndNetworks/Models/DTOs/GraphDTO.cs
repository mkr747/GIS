namespace Models
{
    public class GraphDTO
    {
        public int Verticies { get; set; }

        public int[,] AdjacencyTable { get; set; }

        public GraphDTO()
        {
        }
    }
}
