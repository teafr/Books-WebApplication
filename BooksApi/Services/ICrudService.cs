using booksAPI.Models.DatabaseModels;

namespace web_api_for_books_app.Services
{
    public interface ICrudService<TEntity> where TEntity : class
    {
        Task<List<TEntity>?> GetAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity review);
        Task DeleteAsync(TEntity review);
        Task UpdateAsync(TEntity review);
    }
}