using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.ElementoCancha;
using Microsoft.AspNetCore.Authorization;

namespace WebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("elementoscancha")]
    public class ElementosCanchaController : ControllerBase
    {
        private readonly ElementosCanchaMG _elementosCanchaManager;

        public ElementosCanchaController(ElementosCanchaMG elementoCanchaManager)
        {
            _elementosCanchaManager = elementoCanchaManager;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<ElementosCancha>>> Listado()
        {
            IEnumerable<ElementosCancha> response;
            try
            {
                response = await _elementosCanchaManager.GetAllAsync();
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
        public async Task<ActionResult<IEnumerable<ElementosCancha>>> BuscarAsignacionPorID(int id)
        {
            ElementosCancha response;
            try
            {
                response = await _elementosCanchaManager.GetByIdAsync(id);
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
        public async Task<ActionResult<ElementosCancha>> Add(AltaAsignacionElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.AddAsync(dto);
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


        [HttpPut("update/cantidad/agregar")]
        public async Task<ActionResult<ElementosCancha>> AgregarCantidad(UpdateCantidadAsignacionDTO dto)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.AddCantidad(dto);
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


        [HttpPut("update/cantidad/restar")]
        public async Task<ActionResult<ElementosCancha>> RestarCantidada(UpdateCantidadAsignacionDTO dto)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.RestarCantidad(dto);
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
        public async Task<ActionResult<ElementosCancha>> Delete(int id)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.DeleteAsync(id);
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
