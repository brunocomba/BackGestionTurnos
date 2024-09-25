using Models.ConnectionDB;
using Models.DTOs.Deporte; // DTOs de Deporte

namespace Models.Managers
{
    public class DeporteMG : GenericMG<Deporte>
    {
        public DeporteMG(AppDbContext context) : base(context)
        {
        }

        public async Task<string> AddAsync(AltaDeporteDTO dto)
        {
            if (dto.Name == null)
            {
                throw new Exception("Error: Debe introducir un nombre");
            }

            _v.SoloLetras(dto.Name);
            _v.SoloNumeros(dto.cantJugadores);
            _v.MayorDe0(dto.cantJugadores);
            await _v.NombreRegistrado(dto.Name);

            Deporte dep = new Deporte();
            {
                dep.Name = dto.Name.ToUpper(); dep.cantJugadores = dto.cantJugadores;
            }
            
            await _context.Deportes.AddAsync(dep);
            await _context.SaveChangesAsync();

            return $"Deporte registrado con éxito";

        }


        public async Task<string> Update(UpdateDeporteDTO dto)
        {
            if (dto.Name == null )
            {
                throw new Exception("Error: Debe introducir un nombre");
            }

            _v.MayorDe0(dto.idDepMod); _v.MayorDe0(dto.cantJugadores);
            _v.SoloNumeros(dto.cantJugadores); _v.SoloNumeros(dto.idDepMod);
            _v.SoloLetras(dto.Name);
            var dep = await _v.IdRegistrado(dto.idDepMod);
            await _v.NombreRegistradoMenosActual(dto.Name, dep.Name);

            // Modificar objeto
            dep.Name = dto.Name.ToUpper(); dep.cantJugadores = dto.cantJugadores;

            _context.Deportes.Update(dep);
            await _context.SaveChangesAsync();

            return ("Deporte actualizado con éxito");

        }



    }
}
