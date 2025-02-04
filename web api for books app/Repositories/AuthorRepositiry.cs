using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public class AuthorRepositiry : IRepository<Author>
    {
        private readonly LibraryContext _context;
        public AuthorRepositiry(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<Author> CreateAsync(Author newAuthor)
        {
            await _context.Authors.AddAsync(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }

        public async Task DeleteAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
