using Microsoft.EntityFrameworkCore;
using Models.ConnectionDB;
using Models.Interfaces;


namespace Models.Managers
{
    public class GenericMG<T> : IGenericMG<T> where T : class  // Limita T a tipos que implementen IConId
    {
        protected readonly AppDbContext _context;

        protected readonly Validaciones<T> _v;

        public GenericMG(AppDbContext context)
        {
            _context = context;
            _v = new Validaciones<T>(context); // Inicializa la instancia de validaciones

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"No se enontro {typeof(T).Name} con el ID {id}");
            }
            return entity;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"No se enontro {typeof(T).Name} con el ID {id}");
            }
            _context.Set<T>().Remove(entity);   
            await _context.SaveChangesAsync();

            return $"{typeof(T).Name} eliminado con exito";
        }


        // metodo para filtrar por nombre
        public async Task<IEnumerable<T>> FiltrarPorNombreOApellido(string data)
        {

            if (typeof(IConName).IsAssignableFrom(typeof(T))) // verifica si el tipo T (la clase genérica) implementa la interfaz IConName O la interfaz IConNombreAndApellido
            {
                var list = await _context.Set<T>().ToListAsync();

                if (data != null)
                {
                    list =  list.Where(t => ((IConName)t).Name.ToUpper().Contains(data.ToUpper())).ToList();

                    return list;
                }
            }

            if (typeof(IConNombreAndApellido).IsAssignableFrom(typeof(T))) 
            {
                var list = await _context.Set<T>().ToListAsync();

                if (data != null)
                {
                    list = list.Where(t => ((IConNombreAndApellido)t).Nombre.ToUpper().Contains(data.ToUpper()) || ((IConNombreAndApellido)t).Apellido.ToUpper().Contains(data.ToUpper())).ToList();

                    return list;
                }
            }

            throw new Exception($"Error interno");
        }


    }
}
