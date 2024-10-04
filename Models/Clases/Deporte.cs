


using Models.Interfaces;

namespace Models
{
    public class Deporte : IConName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int cantJugadores { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
