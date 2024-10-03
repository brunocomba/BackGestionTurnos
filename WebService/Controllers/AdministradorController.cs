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
    //[Authorize] // solo los usuarios autenticados puedan acceder a esos recursos
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
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("login")]
        [AllowAnonymous] // Este método se puede acceder sin autenticación
        public async Task<ActionResult> LogIn(LoginDTO dto)
        {
            Administrador response;
            try
            {
                response = await _administradorManager.ValidateLogin(dto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message); // manejo para errores inesperados
            }

            // Verifica si la respuesta es nula (credenciales inválidas)
            if (response == null)
            {
                return Unauthorized("Error: Email y/o contraseña incorrecta.");
            }

            // Crear el token JWT
            var token = GenerateJwtToken(response);

            return Ok(new { token }); // Devuelve el token en un objeto
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


        [HttpGet ("buscar/porDni{dni}")]
        public async Task<ActionResult<Administrador>> buscar_por_dni(int dni)
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
        [AllowAnonymous] // Este método se puede acceder sin autenticación

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
