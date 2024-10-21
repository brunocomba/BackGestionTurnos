using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.Cancha; // DTOs de Cancha
using Microsoft.AspNetCore.Authorization;

namespace WebService.Controllers
{
    [Authorize]
    [ApiController] 
    [Route("canchas")]
    public class CanchaController : ControllerBase
    {
        private readonly CanchaMG _canchaManager;

        public CanchaController(CanchaMG canchaManager)
        {
            _canchaManager = canchaManager;
        }

        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Cancha>>> Listado()
        {
            IEnumerable<Cancha> response;
            try
            {
                response = await _canchaManager.GetAllAsync();
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
        public async Task<ActionResult<IEnumerable<Cancha>>> Buscar(int id)
        {
            Cancha response;
            try
            {
                response = await _canchaManager.GetByIdAsync(id);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No tienes permiso para acceder a este recurso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            };

        }


        [HttpGet("filtrarPorNombreOApellido")]
        public async Task<ActionResult<IEnumerable<Cancha>>> Filtrar(string data)
        {
            IEnumerable<Cancha> response;
            try
            {
                response = await _canchaManager.FiltrarPorNombreOApellido(data);
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
        public async Task<ActionResult<Cancha>> Add(AltaCanchaDTO dto)
        {
            string response;
            try
            {
                response = await _canchaManager.AddAsync(dto);
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
        public async Task<ActionResult<Cancha>> Update(UpdateCanchaDTO dto)
        {
            string response;
            try
            {
                response = await _canchaManager.Update(dto);
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
        public async Task<ActionResult<Cancha>> Delete(int id)
        {
            string response;
            try
            {
                response = await _canchaManager.DeleteAsync(id);
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
