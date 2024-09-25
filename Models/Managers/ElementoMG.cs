using Models.Clases;
using Models.ConnectionDB;
using Models.DTOs.Elemento;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Models.Managers
{
    public class ElementoMG : GenericMG<Elemento>
    {
        public ElementoMG(AppDbContext context) : base(context)
        {
        }


        public async Task<string> AddAsync(AltaElementoDTO dto)
        {
            if (dto.Name == null )
            {
                throw new Exception("Error: Debe introducir un nombre");
            }
            _v.MayorDe0(dto.Stock);
            _v.SoloNumeros(dto.Stock);
            _v.SoloLetras(dto.Name);
            await _v.NombreRegistrado(dto.Name);

            Elemento elemento = new Elemento();
            {
                elemento.Name = dto.Name.ToUpper(); elemento.Stock = dto.Stock;
            }

            await _context.Elementos.AddAsync(elemento);
            await _context.SaveChangesAsync();

            return ("Elemento registrado con éxito");
        }


        public async Task<string> AddStock(UpdateStockElementoDTO dto)
        {
            _v.MayorDe0(dto.Stock); _v.MayorDe0(dto.idElementoMod);
            _v.SoloNumeros(dto.Stock); _v.SoloNumeros(dto.idElementoMod);
            var elemento = await _v.IdRegistrado(dto.idElementoMod);

            // agregar stock
            elemento.Stock = elemento.Stock + dto.Stock;

            _context.Elementos.Update(elemento);
            await _context.SaveChangesAsync();

            return $"Stock actualizado.\n--{elemento.Stock}";
        }
 
        
        public async Task<string> RestarStock(UpdateStockElementoDTO dto)
        {
            _v.MayorDe0(dto.Stock); _v.MayorDe0(dto.idElementoMod);
            _v.SoloNumeros(dto.Stock); _v.SoloNumeros(dto.idElementoMod);
            var elemento = await _v.IdRegistrado(dto.idElementoMod);

            // restar stock

            if (elemento.Stock - dto.Stock < 0)
            {
                throw new Exception("Error: El stock no puede quedar en numero negativo");
            }

            elemento.Stock = elemento.Stock - dto.Stock;

            _context.Elementos.Update(elemento);
            await _context.SaveChangesAsync();

            return $"Stock actualizado.\n--{elemento.Stock}";

        }


        public async Task<string> UpdateNombre(UpdateNombreElementoDTO dto)
        {
            if (dto.Name == null)
            {
                throw new Exception("Error: Debe introducir un nombre");
            }

            _v.SoloLetras(dto.Name);
            _v.SoloNumeros(dto.idElementoMod);
            _v.MayorDe0(dto.idElementoMod);
            var elemento = await _v.IdRegistrado(dto.idElementoMod);
            await _v.NombreRegistradoMenosActual(dto.Name, elemento.Name);

            // modificar el objeto
            elemento.Name = dto.Name.ToUpper();

            _context.Elementos.Update(elemento);
            await _context.SaveChangesAsync();

            return $"Elemento actualizado con éxito";

        }


    }
}
