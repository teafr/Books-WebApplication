using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext bookcontext)
        {
            _context = bookcontext;
        }

        public async Task<List<Book>> GetAsync()
        {
            var books = await _context.Books.Include(a => a.Author).ToListAsync();
            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<Book> CreateAsync(Book book)
        {
            Author author = await _context.Authors.FindAsync(book.Author.Id);

            if (author != null)
            {
                author!.Books!.Add(book);
                book.Author = author;
                book.AuthorId = author.Id;
                _context.Attach(author);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
