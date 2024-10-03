using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.Turno;

namespace WebService.Controllers
{ 
    //[Authorize] // solo los usuarios autenticados puedan acceder a esos recursos    
    [ApiController]
    [Route("turnos")]
    public class TurnoController : ControllerBase
    {
        private readonly TurnosMG _turnosmanager;

        public TurnoController(TurnosMG turnosmanager)
        {
            _turnosmanager = turnosmanager;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Turno>>> Listado()
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.GetAllAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<IEnumerable<Turno>>> BuscarTurnoPorID(int id)
        {
            Turno response;
            try
            {
                response = await _turnosmanager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }



        [HttpGet("filtrar/por/cliente")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoCliente(string criterio)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosDeCliente(criterio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpGet("filtrar/por/semana")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoSemana(DateTime fecha)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosSemanaAsync(fecha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        [HttpGet("filtrar/por/mes")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoMes(DateTime fecha)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosDelMesAsync(fecha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        [HttpGet("filtrar/por/dia")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoDia(DateTime fecha)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosDelDia(fecha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        [HttpPost("add")]
        public async Task<ActionResult<Turno>> Add(AltaTurnoDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.RegistrarAsync(dto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("updateDay")]
        public async Task<ActionResult<Turno>> UpdateDay(UpdateDayTurnoDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.UpdateDay(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("updateHorario")]
        public async Task<ActionResult<Turno>> UpdateHorario(UpdateHorarioTurnoDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.UpdateHorario(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("updateCliente")]
        public async Task<ActionResult<Turno>> UpdateCliente(UpdateClienteTurnoDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.UpdateCliente(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("updateCancha")]
        public async Task<ActionResult<Turno>> UpdateCancha(UpdateCanchaTurnoDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.UpdateCancha(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Turno>> Delete(int id)
        {
            string response;
            try
            {
                response = await _turnosmanager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet("ganancias/mes")]
        public async Task<ActionResult<decimal>> GananciasDelMes(DateTime fecha)
        {
            decimal response;
            try
            {
                response = await _turnosmanager.ResultadoEconomicoMes(fecha);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(response);

        }


        [HttpGet("ganancias/semana")]
        public async Task<ActionResult<decimal>> GananciasDeLaSemana(DateTime fecha)
        {
            decimal response;
            try
            {
                response = await _turnosmanager.ResultadoEconomicoSemana(fecha);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(response);

        }

        [HttpGet("ganancias/anio")]
        public async Task<ActionResult<decimal>> GananciasDelAnio(int anio)
        {
            decimal response;
            try
            {
                response = await _turnosmanager.ResultadoEconomicoAnio(anio);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(response);

        }
    }
}
