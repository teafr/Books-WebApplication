using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T newItem);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}