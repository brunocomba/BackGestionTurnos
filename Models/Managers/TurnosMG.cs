using Microsoft.EntityFrameworkCore;
using Models.Clases;
using Models.ConnectionDB;
using Models.DTOs.Turno;

namespace Models.Managers
{
    public class TurnosMG : GenericMG<Turno>
    {
        private readonly ClienteMG _clienteManager;
        private readonly CanchaMG _canchaManager;
        private readonly AdministradorMG _admManager;


        public TurnosMG(AppDbContext context, ClienteMG clienteManager, CanchaMG canchaManager, AdministradorMG admManager) : base(context)
        {
            _clienteManager = clienteManager;
            _canchaManager = canchaManager;
            _admManager = admManager; 
        }

        
        // Metodos privados de verificacion
        private bool TurnoRegistrado(TimeSpan horario, DateTime fecha, Cancha cancha)
        {
            var turnos = _context.Turnos.ToList();
            foreach (var turno in turnos)
            {
                if (turno.Horario == horario && turno.Fecha.Date == fecha.Date && turno.Cancha == cancha)
                {
                    throw new Exception($"El turno solicitado ya se encuentra registrado.");
                }
            }
            return false;
        }

        private bool EsFechaPasada(DateTime fecha)
        {
            var fechaHoy = DateTime.Now.Date;

            if (fecha.Date < fechaHoy)
            {
                throw new Exception(" No se puede registrar un turno con una fecha anterior a la actual.");
            }
            return false;
        }

        private bool EsHorarioPasado(TimeSpan horario)
        {
            var tiempoActual = DateTime.Now.TimeOfDay;

            if (horario < tiempoActual)
            {
                throw new Exception("No se puede registrar un turno con un horario anterior a la actual.");
            }
            return false;

        }

        private decimal CalcularPrecioPorJugador(Cancha cancha)
        {
            var cantJugadores = cancha.Deporte.cantJugadores;
            var precioCancha = cancha.Precio;

            return precioCancha / cantJugadores;
        }

        private bool ClienteConMismaFechaTurno(DateTime fechaNew, TimeSpan horarioNew, Cliente cliente)
        {
            var turnos =  _context.Turnos.ToList();   
            foreach (var turno in turnos)
            {
                if (turno.Cliente == cliente && fechaNew.Date == turno.Fecha.Date && horarioNew == turno.Horario)
                {
                    throw new Exception("El cliente que quieres cambiar ya tiene un turno registrado para el mismo dia y horario.");
                }
            }
            return false;

        } 

        private bool CanchaConMismaFechaTurno(DateTime fechaNew, TimeSpan horarioNew, Cancha cancha)
        {
            var turnos = _context.Turnos.ToList();
            foreach (var turno in turnos)
            {
                if (turno.Cancha == cancha && fechaNew.Date == turno.Fecha.Date && horarioNew == turno.Horario)
                {
                    throw new Exception("La cancha que quieres cambiar ya tiene un turno registrado para el mismo dia y horario.");
                }
            }
            return false;

        }

        private TimeSpan ConvertirStringEnTimeSpan(string horario)
        {
            bool conversionExitosa = TimeSpan.TryParse(horario, out TimeSpan timeSpan);

            if (conversionExitosa == false)
            {
                throw new Exception("No se pudo realzar la convercion.");
            }

            return timeSpan;
        }

        public override async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await _context.Set<Turno>()
                .Include(t => t.Administrador)
                .Include(t => t.Cliente)
                .Include(t => t.Cancha)
                .ToListAsync();

        }

        public override async Task<Turno> GetByIdAsync(int id)
        {
            var turno = await _context.Set<Turno>()
                .Include (t => t.Administrador)
                .Include(t => t.Cliente)
                .Include(t => t.Cancha)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (turno == null)
            {
                throw new Exception($"No se encontró Turno con el ID {id}");
            }
            return turno;
        }

     

        // METODOS CRUD
        public async Task<string> RegistrarAsync(AltaTurnoDTO dto)
        {
            var formatoHr = ConvertirStringEnTimeSpan(dto.Horario);
            _v.MayorDe0(dto.idCliente); _v.MayorDe0(dto.idCancha);

            var cancha = await _canchaManager.GetByIdAsync(dto.idCancha);
            var cliente = await _clienteManager.GetByIdAsync(dto.idCliente);
            
            TurnoRegistrado(formatoHr, dto.Fecha, cancha);
            EsFechaPasada(dto.Fecha);
            EsHorarioPasado(formatoHr);

            Turno turno = new Turno();
            {
                turno.Horario = formatoHr; turno.Fecha = dto.Fecha.Date; turno.Cliente = cliente; turno.Cancha = cancha;
            }
           
            await _context.Turnos.AddAsync(turno);
            await _context.SaveChangesAsync();


            return $"Turno registrado con exito.\nDia: {turno.Fecha.ToString("yyyy-MM-dd")}\nHorario: {turno.Horario.ToString(@"hh\:mm")}\nCancha: {turno.Cancha.Name}\nCliente: {turno.Cliente.Nombre} {turno.Cliente.Apellido}\n" +
                $"Precio por jugador ${CalcularPrecioPorJugador(cancha)}";

        }

        

        public async Task<string>Update(UpdateDTO dto)
        {
            _v.MayorDe0(dto.idTurnoMod);
            _v.SoloNumeros(dto.idTurnoMod);

            var turno = await GetByIdAsync(dto.idTurnoMod);

            EsFechaPasada(dto.fechaNew);

            var formatoHr = ConvertirStringEnTimeSpan(dto.Horario);
            TurnoRegistrado(formatoHr, turno.Fecha, turno.Cancha);

            var clienteNew = await _clienteManager.GetByIdAsync(dto.idClienteNew);
            ClienteConMismaFechaTurno(dto.fechaNew, formatoHr,  clienteNew);

            var canchaNew = await _canchaManager.GetByIdAsync(dto.idCanchaNew);

            CanchaConMismaFechaTurno(dto.fechaNew, formatoHr, canchaNew);

            // modificar fecha
            turno.Fecha = dto.fechaNew.Date;
            turno.Horario = formatoHr;
            turno.Cliente = clienteNew;
            turno.Cancha = canchaNew;


            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();

            return ("Turno actualizado con exito");
        }


        // Filtrado de turnos
        public async Task<IEnumerable<Turno>> TurnosSemanaAsync(DateTime fecha)
        {
            // Calcular el inicio de la semana (lunes)
            DateTime inicioSemana = fecha.AddDays(-(int)fecha.DayOfWeek + (fecha.DayOfWeek == DayOfWeek.Sunday ? -6 : 1));   // -(int)fecha.DayOfWeek nos da cuantos dias debemos restar para llegar al domingo
                                                                              // si dayOfWeek es domingo que seria (0) que le sume -6
                                                                              // sino que le sume 1 (:) = sino se da (?) = si se da
                                                                              // sumamos uno para llegar al lunes o restamos 6 para llegar al lunes anterior



            // Calcular el final de la semana (domingo)
            DateTime finSemana = inicioSemana.AddDays(6);

            
            // Filtrar los turnos que están en ese rango
            var turnosDeLaSemana = await _context.Turnos.Where(t => t.Fecha >= inicioSemana && t.Fecha <= finSemana)
                .Include(t => t.Administrador)
                .Include(t => t.Cliente)
                .Include(t => t.Cancha)
                .ToListAsync();

            return turnosDeLaSemana;

        }

        public async Task<IEnumerable<Turno>> TurnosDelMesAsync(DateTime fecha)
        {
            int mes = fecha.Month;
            int año = fecha.Year;

            // Filtrar turnos que coincidan con el mes y año proporcionados
            var turnosDelMes = await _context.Turnos.Where(t => t.Fecha.Month == mes && t.Fecha.Year == año).Include(t => t.Administrador)
                .Include(t => t.Cliente)
                .Include(t => t.Cancha)
                .ToListAsync();


            return turnosDelMes;
        }

        public async Task<IEnumerable<Turno>> TurnosDelDia(DateTime fecha)
        {
            var turnosDelDia = await _context.Turnos.Where(t => t.Fecha.Date == fecha.Date).Include(t => t.Administrador)
                .Include(t => t.Cliente)
                .Include(t => t.Cancha)
                .ToListAsync();

            return turnosDelDia;
        }

        public async Task<IEnumerable<Turno>> TurnosDeCliente(string criterio)
        {
            // Verifica si el criterio es nulo o vacío
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return Enumerable.Empty<Turno>(); 
            }

            // Intenta convertir el criterio a un número entero para la búsqueda por DNI
            bool esNumero = int.TryParse(criterio, out int dni);


            // Filtra los turnos que coinciden con el nombre, apellido o DNI del cliente
            var turnosFiltrados =  await _context.Turnos.Where(t => t.Cliente.Nombre.ToUpper().Contains(criterio.ToUpper()) || t.Cliente.Apellido.ToUpper().Contains(criterio.ToUpper()) ||
                             (esNumero == true && t.Cliente.Dni == dni)).Include(t => t.Administrador)
                .Include(t => t.Cliente)
                .Include(t => t.Cancha)
                .ToListAsync();


            return turnosFiltrados;
        }

        // Resultados economicos
        public async Task<decimal> ResultadoEconomicoMes(DateTime fecha)
        {
            var turnosDelMes = await TurnosDelMesAsync(fecha);

            decimal resultado = 0;
            foreach (var turno in turnosDelMes)
            {
                if (turno.Cancha != null)
                {
                    resultado += turno.Cancha.Precio;
                }
            }

            return resultado;
        }


        public async Task<decimal> ResultadoEconomicoSemana(DateTime fecha)
        {
            var turnosSemana = await TurnosSemanaAsync(fecha);

            decimal resultado = 0;
            foreach (var turno in turnosSemana)
            {
                if (turno.Cancha != null)
                {
                    resultado += turno.Cancha.Precio;
                }
            }

            return resultado;
        }


        public async Task<decimal> ResultadoEconomicoAnio(int anio)
        {

            var turnosDelAnio = await _context.Turnos.Where(t => t.Fecha.Year == anio).ToListAsync();

            if (anio > DateTime.Now.Year) // NO HAY TURNOS PARA ESE ANIO
            {
                throw new Exception($"Aun no estamos en el año {anio}. Esperemos seguir sumando añoa juntos.");
            }

            decimal resultado = 0;
            foreach (var turno in turnosDelAnio)
            {
                if (turno.Cancha != null)
                {
                    resultado += turno.Cancha.Precio;
                }
            }

            return resultado;  // Devuelve el valor decimal
        }
    }
}
