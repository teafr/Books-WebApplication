namespace booksAPI.Repositories
{
    public interface ICrudRepository<TEntity>
    {
        Task<List<TEntity>?> GetAsync();

        Task<TEntity?> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity newItem);

        Task UpdateAsync(TEntity item);

        Task DeleteAsync(TEntity item);

        Task DeleteByIdAsync(int id);
    }
}