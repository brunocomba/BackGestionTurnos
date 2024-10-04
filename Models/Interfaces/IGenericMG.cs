

namespace Models.Interfaces
{
    public interface IGenericMG <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<string> DeleteAsync(int id);
    }
}
