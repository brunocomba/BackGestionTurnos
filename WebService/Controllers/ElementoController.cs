using Microsoft.AspNetCore.Mvc;
using Models.Managers;
using Models.DTOs.Elemento; // DTOs de elemento
using Models.Clases;

namespace WebService.Controllers
{
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<IEnumerable<Elemento>>> Buscar(int id)
        {
            Elemento response;
            try
            {
                response = await _elementoManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpPost("add")]
        public async Task<ActionResult<Elemento>> Add(AltaElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementoManager.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/stock/agregar")]
        public async Task<ActionResult<Elemento>> AgregarStock(UpdateStockElementoDTO dto )
        {
            string response;
            try
            {
                response = await _elementoManager.AddStock(dto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/stock/restar")]
        public async Task<ActionResult<Elemento>> RestarStock(UpdateStockElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementoManager.RestarStock(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/nombre")]
        public async Task<ActionResult<Elemento>> UpdateNombre(UpdateNombreElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementoManager.UpdateNombre(dto);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Elemento>> Delete(int id)
        {
            string response;
            try
            {
                response = await _elementoManager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

    }
}
