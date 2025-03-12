using booksAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Repositories
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : class
    {
        protected readonly LibraryContext _context;
        protected readonly DbSet<Entity> dbSet;

        protected BaseRepository(LibraryContext context)
        {
            _context = context;
            dbSet = context.Set<Entity>();
        }

        public async virtual Task<List<Entity>?> GetAsync()
        {
            var items = await dbSet.ToListAsync();
            return items;
        }
        
        public async virtual Task<Entity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task<Entity> CreateAsync(Entity newItem)
        {
            dbSet.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public async virtual Task UpdateAsync(Entity item)
        {
            dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(Entity item)
        {
            dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
