using Microsoft.EntityFrameworkCore;
using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;

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
