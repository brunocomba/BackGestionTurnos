
namespace Models.Clases
{
    public class ElementosCancha 
    {
        public int Id { get; set; }
        public Cancha Cancha { get; set; }
        public Elemento Elemento { get; set; }
        public int Cantidad { get; set; }

    }
}
