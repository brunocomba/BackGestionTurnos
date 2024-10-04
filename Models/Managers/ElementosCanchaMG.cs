using Microsoft.EntityFrameworkCore;
using Models.Clases;
using Models.ConnectionDB;
using Models.DTOs.ElementoCancha;


namespace Models.Managers
{
    public class ElementosCanchaMG : GenericMG<ElementosCancha> 
    {
        private readonly ElementoMG _elementoManager;
        private readonly CanchaMG _canchaManager;


        public ElementosCanchaMG(AppDbContext context, ElementoMG elementoManager, CanchaMG canchaManager) : base(context)
        {
            _elementoManager = elementoManager;
            _canchaManager = canchaManager;
        }


        private async Task<ElementosCancha> Buscar(string nombreElemento, string nombreCancha)
        {
            if (nombreElemento == null || nombreCancha == null)
            {
                throw new Exception("Error: Todos los campos deben estar completos.");
            }


            var elementCancha = await _context.ElementosCancha.FirstOrDefaultAsync(ec => ec.Cancha.Name == nombreCancha.ToUpper() && ec.Elemento.Name == nombreElemento.ToUpper());
            if (elementCancha == null)
            {
                throw new Exception($"Error: No se encontro el elemento {nombreElemento.ToUpper()} registrado en la cancha {nombreCancha.ToUpper()}.");
            }

            return elementCancha;
        }


        private bool ExisteAsignacion(string nombreCancha, string nombreElemento)
        {
            var busqueda = _context.ElementosCancha.FirstOrDefault(ec => ec.Elemento.Name == nombreElemento && ec.Cancha.Name == nombreCancha);

            if (busqueda != null)
            {
                throw new Exception($"Error: Ya existe el elemento {nombreElemento} en la cancha {nombreCancha}.");
            }
            return false;
        }


        private bool StockSuficiente(int stock, int cantidad)
        {
            if (cantidad <= stock)
            {
                return true;
            }

            throw new Exception($"Error: No hay stock suficiente del elemento");
        }


        public async Task<string> AddAsync(AltaAsignacionElementoDTO dto)
        {

            _v.MayorDe0(dto.Cantidad); _v.MayorDe0(dto.idCancha); _v.MayorDe0(dto.idElemento);
            _v.SoloNumeros(dto.Cantidad); _v.SoloNumeros(dto.idCancha); _v.SoloNumeros(dto.idElemento);

            var cancha = await _canchaManager.GetByIdAsync(dto.idCancha);   
            var elemento = await _elementoManager.GetByIdAsync(dto.idCancha);

            ExisteAsignacion(cancha.Name, elemento.Name);
            StockSuficiente(elemento.Stock, dto.Cantidad);

            ElementosCancha ec = new ElementosCancha();
            {
                ec.Elemento = elemento; ec.Cancha = cancha; ec.Cantidad = dto.Cantidad;
            }

            await _context.ElementosCancha.AddAsync(ec);
            await _context.SaveChangesAsync();

            return $"{elemento.Name} asignado correctamente a la cancha {cancha.Name}";

        }


        public async Task<string> AddCantidad(UpdateCantidadAsignacionDTO dto)
        {
            _v.MayorDe0(dto.Cantidad); _v.MayorDe0(dto.idCancha); _v.MayorDe0(dto.idElemento); _v.MayorDe0(dto.idAsignaMod);
            _v.SoloNumeros(dto.Cantidad); _v.SoloNumeros(dto.idCancha); _v.SoloNumeros(dto.idElemento); _v.MayorDe0(dto.idAsignaMod);

            var cancha = await _canchaManager.GetByIdAsync(dto.idCancha);
            var elemento = await _elementoManager.GetByIdAsync(dto.idCancha);

            ExisteAsignacion(cancha.Name, elemento.Name);
            StockSuficiente(elemento.Stock, dto.Cantidad);

            var asig = await Buscar(elemento.Name, cancha.Name);

            // sumar cantidad
            asig.Cantidad = asig.Cantidad + dto.Cantidad;
            _context.ElementosCancha.Update(asig);

            // bajar la cantidad en el stock
            elemento.Stock = elemento.Stock - dto.Cantidad;
            _context.Elementos.Update(elemento);

            await _context.SaveChangesAsync();

            return $"Cantidad actualizada.\n--{asig.Cantidad}\nStock actual elemento: {elemento.Stock}";


        }


        public async Task<string> RestarCantidad(UpdateCantidadAsignacionDTO dto)
        {
            _v.MayorDe0(dto.Cantidad); _v.MayorDe0(dto.idCancha); _v.MayorDe0(dto.idElemento); _v.MayorDe0(dto.idAsignaMod);
            _v.SoloNumeros(dto.Cantidad); _v.SoloNumeros(dto.idCancha); _v.SoloNumeros(dto.idElemento); _v.MayorDe0(dto.idAsignaMod);

            var cancha = await _canchaManager.GetByIdAsync(dto.idCancha);
            var elemento = await _elementoManager.GetByIdAsync(dto.idCancha);

            ExisteAsignacion(cancha.Name, elemento.Name);
            StockSuficiente(elemento.Stock, dto.Cantidad);

            var asig = await Buscar(elemento.Name, cancha.Name);

            // sumar cantidad
            asig.Cantidad = asig.Cantidad - dto.Cantidad;
            _context.ElementosCancha.Update(asig);

            // bajar la cantidad en el stock
            elemento.Stock = elemento.Stock + dto.Cantidad;
            _context.Elementos.Update(elemento);

            await _context.SaveChangesAsync();

            return $"Cantidad actualizada.\n--{asig.Cantidad}\nStock actual elemento: {elemento.Stock}";


        }


    }
}
