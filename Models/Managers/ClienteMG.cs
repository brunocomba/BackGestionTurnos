using Microsoft.EntityFrameworkCore;
using Models.Clases;
using Models.ConnectionDB;
using Models.DTOs.Cliente; // DTOs de Cliente

namespace Models.Managers
{
    public class ClienteMG : GenericMG<Cliente>
    {
        public ClienteMG(AppDbContext context) : base(context)
        {
        }
        public async Task<Cliente> BuscarPorDni(int dni)
        {
            _v.DniCompleto(dni);
            _v.SoloNumeros(dni);
            _v.MayorDe0(dni);

            var cli = await _context.Clientes.FirstOrDefaultAsync(a => a.Dni == dni);

            if (cli == null)
            {
                throw new Exception($"No existe un clienre registrado con el DNI: {dni}");
            }

            return cli;
        }

        public async Task<string> AddAsync(AltaClienteDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nombre) || string.IsNullOrEmpty(dto.Apellido) || string.IsNullOrEmpty(dto.Calle))
            {
                throw new Exception("Error: Todos los campos deben estar completos");
            }
            _v.SoloLetras(dto.Nombre); _v.SoloLetras(dto.Apellido); _v.SoloLetras(dto.Calle);
            _v.SoloNumeros(dto.Dni); _v.SoloNumeros(dto.Altura);
            _v.MayorDe0(dto.Dni); _v.MayorDe0(dto.Altura); _v.TelMayorDe0(dto.Telefono); 
            _v.DniCompleto(dto.Dni);
            await _v.DniRegistrado(dto.Dni);
            _v.Mayor18(dto.fechaNacimiento);
            _v.TelCompleto(dto.Telefono);
               
            var cliNew = new Cliente();
            {
                cliNew.Nombre = dto.Nombre; cliNew.Apellido = dto.Apellido; cliNew.Dni = dto.Dni; cliNew.fechaNacimiento = dto.fechaNacimiento;
                cliNew.Calle = dto.Calle; cliNew.Altura = dto.Altura; cliNew.Telefono = dto.Telefono;
            }
         
            await _context.Clientes.AddAsync(cliNew);
            await _context.SaveChangesAsync();

            return $"Cliente registrado con éxito";
        }

        public async Task<string> Update(UpdateClienteDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nombre) || string.IsNullOrEmpty(dto.Apellido) || string.IsNullOrEmpty(dto.Calle))
            {
                throw new Exception("Error al actualizar: Todos los campos deben estar completos");
            }

            _v.SoloNumeros(dto.idCliMod);
            _v.MayorDe0(dto.idCliMod);
            var cliMod = await _v.IdRegistrado(dto.idCliMod);

            _v.SoloLetras(dto.Nombre); _v.SoloLetras(dto.Apellido); _v.SoloLetras(dto.Calle);
            _v.SoloNumeros(dto.Dni); _v.SoloNumeros(dto.Altura); 
            _v.MayorDe0(dto.Dni); _v.MayorDe0(dto.Altura); _v.TelMayorDe0(dto.Telefono);
            _v.DniCompleto(dto.Dni);
            await _v.DniRegistradoMenosActual(dto.Dni, cliMod.Dni);
            _v.Mayor18(dto.fechaNacimiento);

            // modificar objeto

            cliMod.Nombre = dto.Nombre; cliMod.Apellido = dto.Apellido; cliMod.Dni = dto.Dni; cliMod.fechaNacimiento = dto.fechaNacimiento;
            cliMod.Calle = dto.Calle;  cliMod.Altura = dto.Altura; cliMod.Telefono = dto.Telefono;

            _context.Clientes.Update(cliMod);
            await _context.SaveChangesAsync();

            return $"Cliente actualizado con éxito";

        }


    }
}
