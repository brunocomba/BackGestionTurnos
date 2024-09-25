using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.Managers;
using Models.DTOs.ElementoCancha;

namespace WebService.Controllers
{
    [ApiController]
    [Route("elementoscancha")]
    public class ElementosCanchaController : ControllerBase
    {
        private readonly ElementosCanchaMG _elementosCanchaManager;

        public ElementosCanchaController(ElementosCanchaMG elementoCanchaManager)
        {
            _elementosCanchaManager = elementoCanchaManager;
        }


        [HttpPost("add")]
        public async Task<ActionResult<ElementosCancha>> Add(AltaAsignacionElementoDTO dto)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.AddAsync(dto);   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/cantidad/agregar")]
        public async Task<ActionResult<ElementosCancha>> AgregarCantidad(UpdateCantidadAsignacionDTO dto)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.AddCantidad(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/cantidad/restar")]
        public async Task<ActionResult<ElementosCancha>> RestarCantidada(UpdateCantidadAsignacionDTO dto)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.RestarCantidad(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpDelete("delete{id}")]
        public async Task<ActionResult<ElementosCancha>> Delete(int id)
        {
            string response;
            try
            {
                response = await _elementosCanchaManager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<ElementosCancha>>> Listado()
        {
            IEnumerable<ElementosCancha> response;
            try
            {
                response = await _elementosCanchaManager.GetAllAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }


        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<ElementosCancha>>> Buscar(string nombreElemento, string nombreCancha)
        {
            ElementosCancha response;
            try
            {
                response = await _elementosCanchaManager.FiltrarPorNombreOApellido(id)
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);

        }
    }
}
