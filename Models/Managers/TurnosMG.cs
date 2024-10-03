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

        public TurnosMG(AppDbContext context, ClienteMG clienteManager, CanchaMG canchaManager) : base(context)
        {
            _clienteManager = clienteManager;
            _canchaManager = canchaManager;
        }

        
        // Metodos privados de verificacion
        private bool TurnoRegistrado(TimeSpan horario, DateTime fecha, Cancha cancha)
        {
            var turnos = _context.Turnos.ToList();
            foreach (var turno in turnos)
            {
                if (turno.Horario == horario && turno.Fecha.Date == fecha.Date && turno.Cancha == cancha)
                {
                    throw new Exception($"Error: El turno solicitado ya se encuentra registrado.");
                }
            }
            return false;
        }

        private bool EsFechaPasada(DateTime fecha)
        {
            var fechaHoy = DateTime.Now.Date;

            if (fecha.Date < fechaHoy)
            {
                throw new Exception("Error: No se puede registrar un turno con una fecha anterior a la actual.");
            }
            return false;
        }

        private bool EsHorarioPasado(TimeSpan horario)
        {
            var tiempoActual = DateTime.Now.TimeOfDay;

            if (horario < tiempoActual)
            {
                throw new Exception("Error: No se puede registrar un turno con un horario anterior a la actual.");
            }
            return false;

        }

        private decimal CalcularPrecioPorJugador(Cancha cancha)
        {
            var cantJugadores = cancha.Deporte.cantJugadores;
            var precioCancha = cancha.Precio;

            return precioCancha / cantJugadores;
        }

        private bool ClienteConMismaFechaTurno(Turno turnoDado, Cliente cliente)
        {
            var turnos =  _context.Turnos.ToList();   
            foreach (var turno in turnos)
            {
                if (turno.Cliente == cliente && turnoDado.Fecha == turno.Fecha && turnoDado.Horario == turno.Horario)
                {
                    throw new Exception("El cliente que quieres cambiar ya tiene un turno registrado para el mismo dia y horario.");
                }
            }
            return false;

        } 

        private bool CanchaConMismaFechaTurno(Turno turnoDado, Cancha cancha)
        {
            var turnos = _context.Turnos.ToList();
            foreach (var turno in turnos)
            {
                if (turno.Cancha == cancha && turnoDado.Fecha == turno.Fecha && turnoDado.Horario == turno.Horario)
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
                turno.Horario = formatoHr; turno.Fecha = dto.Fecha.Date ;turno.Cliente = cliente; turno.Cancha = cancha;
            }
           
            await _context.Turnos.AddAsync(turno);
            await _context.SaveChangesAsync();

            return $"Turno registrado con exito.\nDia: {turno.Fecha.Date}\nHorario: {turno.Horario}\nCancha: {turno.Cancha.Name}\nCliente: {turno.Cliente.Nombre} {turno.Cliente.Apellido}\n" +
                $"Precio por jugador> ${CalcularPrecioPorJugador(cancha)}";

        }

             
        public async Task<string> UpdateDay(UpdateDayTurnoDTO dto)
        {
            _v.MayorDe0(dto.idTurnoMod);
            _v.SoloNumeros(dto.idTurnoMod);
            var turno = await _v.IdRegistrado(dto.idTurnoMod);
            EsFechaPasada(dto.fechaNew);
            TurnoRegistrado(turno.Horario, dto.fechaNew, turno.Cancha);

            // modificar fecha
            turno.Fecha = dto.fechaNew.Date;

            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();

            return ("Turno actualizado con exito");
        }


        public async Task<string> UpdateHorario(UpdateHorarioTurnoDTO dto)
        {
            _v.MayorDe0(dto.idTurnoMod);
            _v.SoloNumeros(dto.idTurnoMod);
            var turnoMod = await _v.IdRegistrado(dto.idTurnoMod);

            if (dto.Horario == null)
            {
                throw new Exception("Error: Debe ingresar un horario");
            }

            var formatoHr = ConvertirStringEnTimeSpan(dto.Horario);
            EsHorarioPasado(formatoHr);
            TurnoRegistrado(formatoHr, turnoMod.Fecha, turnoMod.Cancha);

            // Modificar fecha
            turnoMod.Horario = formatoHr;

            _context.Turnos.Update(turnoMod);
            await _context.SaveChangesAsync();

            return $"Turno actualizado con exito";
        }


        public async Task<string> UpdateCliente(UpdateClienteTurnoDTO dto)
        {
            _v.MayorDe0(dto.idClienteNew); _v.MayorDe0(dto.idTurnoMod);
            _v.SoloNumeros(dto.idClienteNew); _v.SoloNumeros(dto.idTurnoMod);

            var turnoMod = await _v.IdRegistrado(dto.idTurnoMod);

            var clienteNew = await _clienteManager.GetByIdAsync(dto.idClienteNew);

            ClienteConMismaFechaTurno(turnoMod, clienteNew);

            // Modificar cliente
            turnoMod.Cliente = clienteNew;

            _context.Turnos.Update(turnoMod);
            await _context.SaveChangesAsync();

            return $"Modificacion realizada con exito";

        }


        public async Task<string> UpdateCancha(UpdateCanchaDTO dto)
        {
            _v.MayorDe0(dto.idCanchaNew); _v.MayorDe0(dto.idTurnoMod);
            _v.SoloNumeros(dto.idCanchaNew); _v.SoloNumeros(dto.idTurnoMod);

            var turnoMod = await _v.IdRegistrado(dto.idTurnoMod);
            var canchaNew = await _canchaManager.GetByIdAsync(dto.idCanchaNew);

            CanchaConMismaFechaTurno(turnoMod, canchaNew);
           
            // Modificar fecha
            turnoMod.Cancha = canchaNew;

            _context.Turnos.Update(turnoMod);
            await _context.SaveChangesAsync();

            return $"Modificacion realizada con exito";
        }


        // Filtrado de turnos
        public async Task<IEnumerable<Turno>> TurnosSemanaAsync(DateTime fecha)
        {
            // Calcular el inicio de la semana (lunes)
            DateTime inicioSemana = fecha.AddDays(-(int)fecha.DayOfWeek + 1); // -(int)fecha.DayOfWeek nos dac cuantos dias debemos restar para llegar al domingo
                                                                              // +1 para byscar el lunes


            // Calcular el final de la semana (domingo)
            DateTime finSemana = inicioSemana.AddDays(6);


            // Filtrar los turnos que están en ese rango
            var turnosDeLaSemana = await _context.Turnos.Where(t => t.Fecha >= inicioSemana && t.Fecha <= finSemana).ToListAsync();
            return turnosDeLaSemana;

        }

        public async Task<IEnumerable<Turno>> TurnosDelMesAsync(DateTime fecha)
        {
            int mes = fecha.Month;
            int año = fecha.Year;

            // Filtrar turnos que coincidan con el mes y año proporcionados
            var turnosDelMes = await _context.Turnos.Where(t => t.Fecha.Month == mes && t.Fecha.Year == año).ToListAsync();

            return turnosDelMes;
        }



        // Resultados economicos
        public async Task<string> ResultadoEconomicoMes(DateTime fecha)
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

            return $"Resultado economico del mes de {fecha.ToString("MMMM")} -- ${resultado}";
        }


        public async Task<string> ResultadoEconomicoSemana(DateTime fecha)
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

            return $"Resultado economico del mes de {fecha.ToString("MMMM")} -- ${resultado}";
        }


    }
}
