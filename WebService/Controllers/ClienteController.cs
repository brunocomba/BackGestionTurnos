using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.Cliente; // DTOs de 

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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Buscar(int id)
        {
            Cliente response;
            try
            {
                response = await _clienteManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPost("add")]
        public async Task<ActionResult<Cliente>> Add(AltaClienteDTO dto)
        {
            string response;
            try
            {
                response = await _clienteManager.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update")]
        public async Task<ActionResult<Cliente>> UpdateNombres(UpdateClienteDTO dto)
        {
            string response;
            try
            {
                response = await _clienteManager.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            string response;
            try
            {
                response = await _clienteManager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

      

    }
}
