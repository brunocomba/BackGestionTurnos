

namespace Models.Clases
{
    public class Turno 
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }

        public Administrador Administrador { get; set; }
        public Cancha Cancha{ get; set; }
        public Cliente Cliente { get; set; }

        //public SINO Asistido
        //{
        //    get
        //    {
        //        var tiempoActual = DateTime.Now.TimeOfDay;
        //        var fechaHoy = DateTime.Now.Date;

        //        if (Horario < tiempoActual || Fecha < fechaHoy)
        //        {
        //            return SINO.SI;
        //        }
        //        return SINO.NO;
        //    }
        //}

        public enum SINO
        {
            SI = 1,
            NO = 0
        }

      
    }
}
