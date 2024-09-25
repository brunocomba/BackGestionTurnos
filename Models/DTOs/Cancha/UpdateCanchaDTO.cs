
namespace Models.DTOs.Cancha
{
    public class UpdateCanchaDTO
    {
        public int idCanchaMod { get; set; }
        public int idDep { get; set; }
        public string? Name { get; set; }
        public decimal Precio { get; set; }
    }
}
