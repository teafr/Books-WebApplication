using booksAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Repositories
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly LibraryContext _context;
        protected readonly DbSet<Entity> dbSet;

        protected BaseRepository(LibraryContext context)
        {
            _context = context;
            dbSet = context.Set<Entity>();
        }

        public virtual async Task<List<Entity>?> GetAsync()
        {
            var items = await dbSet.ToListAsync();
            return items;
        }

        public virtual async Task<Entity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<Entity> CreateAsync(Entity newItem)
        {
            dbSet.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public virtual async Task UpdateAsync(Entity item)
        {
            dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Entity item)
        {
            dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await this.dbSet.FindAsync(id);
            this.dbSet.Remove(entity!);
            await this._context.SaveChangesAsync();
        }
    }
}
