using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Managers;
using Models.DTOs.Deporte; // DTOs de Deporte
using Microsoft.AspNetCore.Authorization; 

namespace WebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("deportes")]
    public class DeporteController : ControllerBase
    {
        private readonly DeporteMG _deporteManager;

        public DeporteController(DeporteMG deporteManager)
        {
            _deporteManager = deporteManager;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Deporte>>> Listado()
        {
            IEnumerable<Deporte> response;
            try
            {
                response = await _deporteManager.GetAllAsync();
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
        public async Task<ActionResult<IEnumerable<Deporte>>> Buscar(int id)
        {
            Deporte response;
            try
            {
                response = await _deporteManager.GetByIdAsync(id);
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
        public async Task<ActionResult<Deporte>> Add(AltaDeporteDTO dto)
        {
            string response;
            try
            {
                response = await _deporteManager.AddAsync(dto);
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
        public async Task<ActionResult<Deporte>> Update(UpdateDeporteDTO dto)
        {
            string response;
            try
            {
                response = await _deporteManager.Update(dto);
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
        public async Task<ActionResult<Deporte>> Delete(int id)
        {
            string response;
            try
            {
                response = await _deporteManager.DeleteAsync(id);
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
