using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _bookcontext;

        public BookRepository(LibraryContext bookcontext)
        {
            _bookcontext = bookcontext;
        }

        public async Task<List<Book>> GetAsync()
        {
            var books = await _bookcontext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookcontext.Books.FindAsync(id);
        }
        public async Task<Book> CreateAsync(Book book)
        {
            _bookcontext.Books.Add(book);
            await _bookcontext.SaveChangesAsync();
            return book;
        }
        public async Task UpdateAsync(Book book)
        {
            _bookcontext.Books.Update(book);
            await _bookcontext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Book book)
        {
            _bookcontext.Books.Remove(book);
            await _bookcontext.SaveChangesAsync();
        }
    }
}
