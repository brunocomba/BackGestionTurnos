using Microsoft.AspNetCore.Mvc;
using Models.Clases;
using Models.DTOs.Administrador;
using Models.DTOs.Filter;

/// Aceceder a las DTOs de Administradores
using Models.Managers;

namespace WebService.Controllers
{
    [ApiController]
    [Route("administradores")]
    public class AdministradorController : ControllerBase
    {
        private readonly AdministradorMG _administradorManager;

        public AdministradorController(AdministradorMG administradorManager)
        {
            _administradorManager = administradorManager;
        }


        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Listado()
        {
            IEnumerable<Administrador> response;
            try
            {
                response = await _administradorManager.GetAllAsync();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet("buscar{id}")]
        public async Task<ActionResult<Administrador>> Buscar(int id)
        {
            Administrador response;
            try
            {
                response = await _administradorManager.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet ("buscarpordni")]
        public async Task<ActionResult<Administrador>> BuscarPorDni(int dni)
        {
            Administrador response;
            try
            {
                response = await _administradorManager.BuscarPorDni(dni);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet("filtrarPorNombreOApellido")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Filtrar(string data)
        {
            IEnumerable<Administrador> response;
            try
            {
                response =  await _administradorManager.FiltrarPorNombreOApellido(data);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpPost("add")]
        public async Task<ActionResult<Administrador>> Add(AltaAdmDTO altaDto)
        {
            string response;
            try
            {
                response = await _administradorManager.AddAsync(altaDto);
            }
            catch (Exception ex) 
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/datospersonales")]
        public async Task<ActionResult<Administrador>> UpdateNombres(UpdateDatosPersonalesAdmDTO dto)
        {
            string response;
            try
            {
                response = await _administradorManager.UpdateDatosPersonales(dto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/email")]
        public async Task<ActionResult<Administrador>> UpdateUsuario(UpdateEmailAdmDTO dto)
        {
            string response;
            try
            {
                response = await _administradorManager.UdpdateEmail(dto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpPut("update/password")]
        public async Task<ActionResult<Administrador>> UpdatePass(UpdatePassAdmDTO dto)
        {
            string response;
            try
            {
                response = await _administradorManager.UpdatePassword(dto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }


        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Administrador>> Delete(int id)
        {
            string response;
            try
            {
                response = await _administradorManager.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(response);
        }

    }
}
