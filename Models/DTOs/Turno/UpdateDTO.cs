using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Turno
{
    public class UpdateDTO
    {
        public int idTurnoMod { get; set; }
        public int idCanchaNew { get; set; }
        public int idClienteNew { get; set; }
        public DateTime fechaNew { get; set; }
        public string Horario { get; set; }


    }
}
