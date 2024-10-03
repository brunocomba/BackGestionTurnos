

using Models.Interfaces;

namespace Models.Clases
{
    public class Cancha : IConName
    {
        public int Id { get; set; }
        public Deporte? Deporte { get; set; }
        public string? Name { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
