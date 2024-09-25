

namespace Models.DTOs.Turno
{
    public class AltaTurnoDTO
    {
        public int idCliente { get; set; }
        public int idCancha { get; set; }
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
    }
}
