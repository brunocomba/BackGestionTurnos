using Microsoft.AspNetCore.Mvc;
using Models.Managers;
using Models.DTOs.Elemento; // DTOs de elemento
using Models.Clases;
using Microsoft.AspNetCore.Authorization;

namespace WebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("elementos")]
    public class ElementoController : ControllerBase
    {
        private readonly ElementoMG _elementoManager;

        public ElementoController(ElementoMG elementoManager)
        {
            _elementoManager = elementoManager;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Elemento>>> Listado()
        {
            IEnumerable<Elemento> response;
            try
            {
                response = await _elementoManager.GetAllAsync();
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
        public async Task<ActionResult<IEnumerable<Elemento>>> Buscar(int id)
        {
            Elemento response;
            try
            {
                response = await _elementoManager.GetByIdAsync(id);
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
        public async Task<ActionResult<Elemento>> Add(AltaElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementoManager.AddAsync(dto);
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


        [HttpPut("update/stock/agregar")]
        public async Task<ActionResult<Elemento>> AgregarStock(UpdateStockElementoDTO dto )
        {
            string response;
            try
            {
                response = await _elementoManager.AddStock(dto);
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


        [HttpPut("update/stock/restar")]
        public async Task<ActionResult<Elemento>> RestarStock(UpdateStockElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementoManager.RestarStock(dto);
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


        [HttpPut("update/nombre")]
        public async Task<ActionResult<Elemento>> UpdateNombre(UpdateNombreElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementoManager.UpdateNombre(dto);
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
        public async Task<ActionResult<Elemento>> Delete(int id)
        {
            string response;
            try
            {
                response = await _elementoManager.DeleteAsync(id);
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
