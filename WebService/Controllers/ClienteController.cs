using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.Cliente; // DTOs de cliente
using Microsoft.AspNetCore.Authorization; 

namespace WebService.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteMG _clienteManager;

        public ClienteController(ClienteMG clienteManager)
        {
            _clienteManager = clienteManager;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listado()
        {
            IEnumerable<Cliente> response;
            try
            {
                response = await _clienteManager.GetAllAsync();
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
        public async Task<ActionResult<IEnumerable<Cliente>>> Buscar(int id)
        {
            Cliente response;
            try
            {
                response = await _clienteManager.GetByIdAsync(id);
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
        public async Task<ActionResult<Cliente>> Add(AltaClienteDTO dto)
        {
            string response;
            try
            {
                response = await _clienteManager.AddAsync(dto);
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
        public async Task<ActionResult<Cliente>> UpdateNombres(UpdateClienteDTO dto)
        {
            string response;
            try
            {
                response = await _clienteManager.Update(dto);
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
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            string response;
            try
            {
                response = await _clienteManager.DeleteAsync(id);
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
