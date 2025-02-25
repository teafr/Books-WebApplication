using booksAPI.Models;

namespace booksAPI.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>?> GetAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T newItem);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}