using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.Turno;

namespace WebService.Controllers
{
    [Authorize]
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
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<IEnumerable<Turno>>> BuscarTurnoPorID(int id)
        {
            Turno response;
            try
            {
                response = await _turnosmanager.GetByIdAsync(id);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        [HttpGet("filtrar/por/cliente")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoCliente(string criterio)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosDeCliente(criterio);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        [HttpGet("filtrar/por/semana")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoSemana(DateTime fecha)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosSemanaAsync(fecha);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        [HttpGet("filtrar/por/mes")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoMes(DateTime fecha)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosDelMesAsync(fecha);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        [HttpGet("filtrar/por/dia")]
        public async Task<ActionResult<IEnumerable<Turno>>> ListadoDia(DateTime fecha)
        {
            IEnumerable<Turno> response;
            try
            {
                response = await _turnosmanager.TurnosDelDia(fecha);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        [HttpPost("add")]
        public async Task<ActionResult<Turno>> Add(AltaTurnoDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.RegistrarAsync(dto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("update")]
        public async Task<ActionResult<Turno>> Update(UpdateDTO dto)
        {
            string response;
            try
            {
                response = await _turnosmanager.Update(dto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        

        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Turno>> Delete(int id)
        {
            string response;
            try
            {
                response = await _turnosmanager.DeleteAsync(id);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet("ganancias/mes")]
        public async Task<ActionResult<decimal>> GananciasDelMes(DateTime fecha)
        {
            decimal response;
            try
            {
                response = await _turnosmanager.ResultadoEconomicoMes(fecha);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet("ganancias/semana")]
        public async Task<ActionResult<decimal>> GananciasDeLaSemana(DateTime fecha)
        {
            decimal response;
            try
            {
                response = await _turnosmanager.ResultadoEconomicoSemana(fecha);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("ganancias/anio")]
        public async Task<ActionResult<decimal>> GananciasDelAnio(int anio)
        {
            decimal response;
            try
            {
                response = await _turnosmanager.ResultadoEconomicoAnio(anio);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
