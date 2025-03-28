namespace booksAPI.Repositories
{
    public interface IRepository<Entity>
    {
        Task<List<Entity>?> GetAsync();
        Task<Entity?> GetByIdAsync(int id);
        Task<Entity> CreateAsync(Entity newItem);
        Task UpdateAsync(Entity item);
        Task DeleteAsync(Entity item);
        Task DeleteByIdAsync(int id);
    }
}