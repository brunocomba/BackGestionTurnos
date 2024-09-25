

namespace Models.DTOs.Administrador
{
    public class UpdatePassAdmDTO
    {
        public int idAdmiMod { get; set; }
        public string? passAntigua { get; set; }
        public string? passNew { get; set; }
        public string? confirPassNew { get; set; }
    }
}
