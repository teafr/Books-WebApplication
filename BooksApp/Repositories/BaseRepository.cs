using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace web_api_for_books_app.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryContext _context;
        protected readonly DbSet<T> dbSet;

        protected BaseRepository(LibraryContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public async virtual Task<List<T>?> GetAsync()
        {
            var items = await dbSet.ToListAsync();
            return items;
        }

        public async virtual Task<T> CreateAsync(T newItem)
        {
            dbSet.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public async virtual Task DeleteAsync(T item)
        {
            dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task UpdateAsync(T item)
        {
            dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
