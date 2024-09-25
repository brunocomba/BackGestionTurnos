using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Managers;
using Models.DTOs.Deporte; // DTOs de Deporte

namespace WebService.Controllers
{
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<IEnumerable<Deporte>>> Buscar(int id)
        {
            Deporte response;
            try
            {
                response = await _deporteManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpPost("add")]
        public async Task<ActionResult<Deporte>> Add(AltaDeporteDTO dto)
        {
            string response;
            try
            {
                response = await _deporteManager.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update")]
        public async Task<ActionResult<Deporte>> Update(UpdateDeporteDTO dto)
        {
            string response;
            try
            {
                response = await _deporteManager.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Deporte>> Delete(int id)
        {
            string response;
            try
            {
                response = await _deporteManager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

      
    }
}
