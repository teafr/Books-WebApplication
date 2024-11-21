using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookcontext;

        public BookRepository(BookContext bookcontext)
        {
            _bookcontext = bookcontext;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var books = await _bookcontext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookcontext.Books.FindAsync(id);
        }
        public async Task<Book> CreateBookAsync(Book book)
        {
            _bookcontext.Books.Add(book);
            await _bookcontext.SaveChangesAsync();
            return book;
        }
        public async Task UpdateBookAsync(Book book)
        {
            _bookcontext.Books.Update(book);
            await _bookcontext.SaveChangesAsync();
        }
        public async Task DeleteBookAsync(Book book)
        {
            _bookcontext.Books.Remove(book);
            await _bookcontext.SaveChangesAsync();
        }
    }
}
