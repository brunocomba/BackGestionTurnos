

namespace Models.DTOs.Administrador
{
    public class UpdateEmailAdmDTO
    {
        public int idAdmiMod { get; set; }
        public string emailAnterior { get; set; }
        public string? emailNew { get; set; }
        public string confirEmailNew { get; set; }


    }
}
