using Models.ConnectionDB;
using Models.Clases;
using Models.DTOs.Administrador;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // DTOs de Adminsitrador

namespace Models.Managers
{
    public class AdministradorMG : GenericMG<Administrador>
    {
        public AdministradorMG(AppDbContext context, IConfiguration configuration) : base(context)
        {
        }

        // Método para hashear la contraseña
        private string HashPassword(string password)
        {
            // Utiliza BCrypt para hashear la contraseña
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Método para verificar la contraseña
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Utiliza BCrypt para verificar la contraseña
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

   

        public async Task<Administrador> BuscarPorDni(int dni)
        {
            _v.DniCompleto(dni);
            _v.SoloNumeros(dni);
            _v.MayorDe0(dni);

            var list = await _context.Administradores.ToListAsync();
            var adm =  list.FirstOrDefault(a => a.Dni == dni);

            if (adm == null)
            {
                throw new Exception($"No existe un administrador registrado con el DNI: {dni}");
            }

            return adm;
        }

        public async Task<Administrador> ValidateLogin(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            {
                throw new Exception("Todos los campos deben estar completos");
            }

            _v.CumpleRequisitosEmail(dto.Email);

            var adm = await _context.Administradores.FirstOrDefaultAsync(a => a.Email == dto.Email);

            // Verifica si se encontró el administrador
            if (adm == null)
            {
                throw new Exception("Email y/o contraseña incorrecta.");
            }

            // Verifica si la contraseña es correcta
            if (VerifyPassword(dto.Password, adm.Password) == false)
            {
                throw new Exception("Email y/o contraseña incorrecta.");
            }

            return adm;

        }


        public async Task<string> AddAsync(AltaAdmDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nombre) || string.IsNullOrEmpty(dto.Apellido) || string.IsNullOrEmpty(dto.Calle) || string.IsNullOrEmpty(dto.Email)
                || string.IsNullOrEmpty(dto.confirEmail) || string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.confirPass))
            {
                throw new Exception("Todos los campos deben estar completos");
            }

            _v.MayorDe0(dto.Altura); _v.MayorDe0(dto.Dni); 
            await _v.DniRegistrado(dto.Dni);
            _v.SoloLetras(dto.Nombre); _v.SoloLetras(dto.Apellido); _v.SoloLetras(dto.Calle);
            _v.SoloNumeros(dto.Dni); _v.SoloNumeros(dto.Altura);
            _v.DniCompleto(dto.Dni);
            _v.Mayor18(dto.fechaNacimiento);
            await _v.EmailRegistrado(dto.Email);
            _v.CumpleRequisitosEmail(dto.Email);
            _v.ConfirmarEmail(dto.Email, dto.confirEmail);
            _v.CumpleRequisitosPass(dto.Password);
            _v.ConfirmarPass(dto.Password, dto.confirPass);
           
            var adm = new Administrador();
            {
                adm.Nombre = dto.Nombre;  adm.Apellido = dto.Apellido; adm.Calle = dto.Calle; adm.Altura = dto.Altura;  adm.Dni = dto.Dni;
                adm.fechaNacimiento = dto.fechaNacimiento.Date; adm.Email = dto.Email;
                adm.Password = HashPassword(dto.Password); // hashear la contrasnia
            }

            await _context.Administradores.AddAsync(adm);
            await _context.SaveChangesAsync();

            return $"Administrador registrado con éxito";
        }


        public async Task<string> UpdateDatosPersonales(UpdateDatosPersonalesAdmDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nombre) || string.IsNullOrEmpty(dto.Apellido) || string.IsNullOrEmpty(dto.Calle))
            {
                throw new Exception("Erorr al actualizar: Todos los campos deben estar completos");
            }

            _v.SoloNumeros(dto.idAdmiMod);
            _v.MayorDe0(dto.Dni); _v.MayorDe0(dto.Altura); _v.MayorDe0(dto.idAdmiMod);
            var admiMod = await _v.IdRegistrado(dto.idAdmiMod);

            _v.SoloLetras(dto.Nombre); _v.SoloLetras(dto.Apellido); _v.SoloLetras(dto.Calle);
            _v.SoloNumeros(dto.Dni); _v.SoloNumeros(dto.Altura);
            _v.DniCompleto(dto.Dni);
            await _v.DniRegistradoMenosActual(dto.Dni, admiMod.Dni);
            _v.Mayor18(dto.fechaNacimiento);

            
            // Modificar objeto
            admiMod.Nombre = dto.Nombre; admiMod.Apellido = dto.Apellido; admiMod.Dni = dto.Dni;
            admiMod.Calle = dto.Calle;  admiMod.Altura = dto.Altura; admiMod.fechaNacimiento = dto.fechaNacimiento.Date;

            _context.Administradores.Update(admiMod);   
            await _context.SaveChangesAsync();

            return $"Administrador actualizado con éxito";
        }


        public async Task<string> UpdatePassword(UpdatePassAdmDTO dto)
        {
            if (string.IsNullOrEmpty(dto.passAntigua) || string.IsNullOrEmpty(dto.passNew) || string.IsNullOrEmpty(dto.confirPassNew))
            {
                throw new Exception("No se puede actualizar: Todos los campos deben estar completos");
            }

            _v.SoloNumeros(dto.idAdmiMod);
            _v.MayorDe0(dto.idAdmiMod);
            var admiMod = await _v.IdRegistrado(dto.idAdmiMod); 

            _v.PassAnteriorCorrecta(dto.passAntigua, admiMod.Password);
            _v.PassRegistradaDistinta(dto.passNew, admiMod.Password);
            _v.CumpleRequisitosPass(dto.passNew);
            _v.ConfirmarPass(dto.passNew, dto.confirPassNew);

            // Modificar objeto
            admiMod.Password = dto.passNew;

            _context.Administradores.Update(admiMod);
            await _context.SaveChangesAsync();

            return $"Administrador actualizado con éxito";
        }


        public async Task<string> UdpdateEmail(UpdateEmailAdmDTO dto)
        {
            if (string.IsNullOrEmpty(dto.emailNew))
            {
                throw new Exception("No se puede actualizar: Todos los campos deben estar completos");
            }

            _v.SoloNumeros(dto.idAdmiMod);
            _v.MayorDe0(dto.idAdmiMod);
            var admiMod = await _v.IdRegistrado(dto.idAdmiMod);

            _v.EmailAnteriorCorrecto(dto.emailAnterior, admiMod.Email);
            _v.CumpleRequisitosEmail(dto.emailNew);
            _v.EmailRegistradoDistinto(dto.emailNew, admiMod.Email);
            await _v.EmailRegistrado(dto.emailNew);
            _v.ConfirmarEmail(dto.emailNew, dto.confirEmailNew);
     
            // Modificar objeto
            admiMod.Email = dto.emailNew;

            _context.Administradores.Update(admiMod);
            await _context.SaveChangesAsync();

            return $"Administrador actualizado con éxito";
        }

        
    }
}
