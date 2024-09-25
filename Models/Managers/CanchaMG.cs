using Models.Clases;
using Models.ConnectionDB;
using Models.DTOs.Cancha;

namespace Models.Managers
{
    public class CanchaMG : GenericMG<Cancha>
    {
        private readonly DeporteMG _deporteManager;

        public CanchaMG(AppDbContext context, DeporteMG deporteManager) : base(context)
        {
            _deporteManager = deporteManager;
        }

        public async Task<string> AddAsync(AltaCanchaDTO dto)
        {
            if (dto.Name == null)
            {
                throw new Exception("Error: Debe introducir un nombre");
            }
            _v.PrecioMayorDe0(dto.Precio);
            _v.SoloLetras(dto.Name);
            _v.SoloNumeros(dto.idDep); _v.SoloNumerosEnPrecio(dto.Precio); 
            await _v.NombreRegistrado(dto.Name);
            var deporte = await _deporteManager.GetByIdAsync(dto.idDep); // Buscar el deporte

            Cancha cancha = new Cancha();
            {
                cancha.Deporte = deporte; cancha.Name = dto.Name; cancha.Precio = dto.Precio;
            }

            await _context.Canchas.AddAsync(cancha);
            await _context.SaveChangesAsync();

            return ("Cancha registrada con éxito");
        }
        
        public async Task<string> Update(UpdateCanchaDTO dto)
        {
            if (dto.Name == null)
            {
                throw new Exception("Error: Debe introducir un nombre");
            }

            _v.SoloLetras(dto.Name);
            _v.SoloNumeros(dto.idCanchaMod); _v.SoloNumeros(dto.idDep); _v.SoloNumerosEnPrecio(dto.Precio);
            _v.MayorDe0(dto.idCanchaMod); _v.MayorDe0(dto.idDep); _v.PrecioMayorDe0(dto.Precio);
            var canchaMod = await _v.IdRegistrado(dto.idCanchaMod);
            await _v.NombreRegistradoMenosActual(dto.Name, canchaMod.Name);
            var deporte = await _deporteManager.GetByIdAsync(dto.idDep); // Buscar el deporte

            // modificar objeto
            canchaMod.Deporte = deporte; canchaMod.Name = dto.Name; canchaMod.Precio = dto.Precio;

            _context.Canchas.Update(canchaMod);
            await _context.SaveChangesAsync();

            return $"Cliente actualizado con éxito";

        }



    }
}
