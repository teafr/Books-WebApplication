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

        public abstract Task<List<T>?> GetAsync();

        public async Task<T> CreateAsync(T newItem)
        {
            dbSet.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public async Task DeleteAsync(T item)
        {
            dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
            dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
