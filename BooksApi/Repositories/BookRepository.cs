using Microsoft.EntityFrameworkCore;
using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using web_api_for_books_app.Repositories;

namespace booksAPI.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context) { }

        public override async Task<List<Book>?> GetAsync()
        {
            var books = await dbSet.ToListAsync();
            return books;
        }
    }
}
