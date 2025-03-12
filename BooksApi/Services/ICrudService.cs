using booksAPI.Models.DatabaseModels;

namespace booksAPI.Services
{
    public interface ICrudService<TEntity> where TEntity : IDatabaseModel
    {
        Task<List<TEntity>?> GetAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity newItem);
        Task DeleteAsync(TEntity item);
        Task UpdateAsync(TEntity existingItem, TEntity itemToUpdate);
    }
}