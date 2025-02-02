using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetBooksAsync();
        Task<T> GetBookByIdAsync(int id);
        Task<T> CreateBookAsync(T book);
        Task UpdateBookAsync(T book);
        Task DeleteBookAsync(T book);
    }
}