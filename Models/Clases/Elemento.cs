

using Models.Interfaces;

namespace Models.Clases
{
    public class Elemento : IConName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
