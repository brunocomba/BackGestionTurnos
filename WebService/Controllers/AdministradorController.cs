using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Clases;
using Models.DTOs.Administrador; /// Aceceder a las DTOs de Administradores
using Models.Managers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebService.Controllers
{
    [ApiController]
    [Route("administradores")]
    public class AdministradorController : ControllerBase
    {
        private readonly AdministradorMG _administradorManager;
        private readonly IConfiguration _configuration;

        public AdministradorController(AdministradorMG administradorManager, IConfiguration configuration)
        {
            _administradorManager = administradorManager;
            _configuration = configuration;
        }


        private string GenerateJwtToken(Administrador admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, admin.Id.ToString()),
                new Claim(ClaimTypes.Role, "Administrador")
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(LoginDTO dto)
        {
            Administrador adm;
            try
            {
                adm = await _administradorManager.ValidateLogin(dto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }



            // Crear el token JWT
            var token = GenerateJwtToken(adm);

            var response = new LoginResponse()
            {
                Token = token,
                Admin = $"{adm.Nombre} {adm.Apellido}"
            };

            return Ok(response); // Devuelve el token en un objeto
        }

        [Authorize]
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Listado()
        {
            try
            {
                var response = await _administradorManager.GetAllAsync();
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

        [Authorize]
        [HttpGet("buscar{id}")]
        public async Task<ActionResult<Administrador>> Buscar(int id)
        {
            Administrador response;
            try
            {
                response = await _administradorManager.GetByIdAsync(id);
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

        [Authorize]
        [HttpGet ("buscar/porDni{dni}")]
        public async Task<ActionResult<Administrador>> buscar_por_dni(int dni)
        {
            Administrador response;
            try
            {
                response = await _administradorManager.BuscarPorDni(dni);
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


        [Authorize]
        [HttpGet("filtrarPorNombreOApellido")]
        public async Task<ActionResult<IEnumerable<Administrador>>> Filtrar(string data)
        {
            IEnumerable<Administrador> response;
            try
            {
                response =  await _administradorManager.FiltrarPorNombreOApellido(data);
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


        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<Administrador>> Add(AltaAdmDTO altaDto)
        {
            string response;
            try
            {
                response = await _administradorManager.AddAsync(altaDto);
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


        [Authorize]
        [HttpPut("update/datospersonales")]
        public async Task<ActionResult<Administrador>> UpdateNombres(UpdateDatosPersonalesAdmDTO dto)
        {
            string response;
            try
            {
                response = await _administradorManager.UpdateDatosPersonales(dto);
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


        [Authorize]
        [HttpPut("update/email")]
        public async Task<ActionResult<Administrador>> UpdateUsuario(UpdateEmailAdmDTO dto)
        {
            string response;
            try
            {
                response = await _administradorManager.UdpdateEmail(dto);
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


        [Authorize]
        [HttpPut("update/password")]
        public async Task<ActionResult<Administrador>> UpdatePass(UpdatePassAdmDTO dto)
        {
            string response;
            try
            {
                response = await _administradorManager.UpdatePassword(dto);
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


        [Authorize]
        [HttpDelete("delete{id}")]
        public async Task<ActionResult<Administrador>> Delete(int id)
        {
            string response;
            try
            {
                response = await _administradorManager.DeleteAsync(id);
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
