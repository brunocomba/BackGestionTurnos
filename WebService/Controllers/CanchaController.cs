using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.Cancha; // DTOs de Cancha

namespace WebService.Controllers
{
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<IEnumerable<Cancha>>> Buscar(int id)
        {
            Cancha response;
            try
            {
                response = await _canchaManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }

        [HttpPost("add")]
        public async Task<ActionResult<Cancha>> Add(AltaCanchaDTO dto)
        {
            string response;
            try
            {
                response = await _canchaManager.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Cancha>> Update(UpdateCanchaDTO dto)
        {
            string response;
            try
            {
                response = await _canchaManager.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Cancha>> Delete(int id)
        {
            string response;
            try
            {
                response = await _canchaManager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

  
    }
}
