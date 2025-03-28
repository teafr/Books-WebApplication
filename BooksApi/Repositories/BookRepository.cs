using booksAPI.Contexts;
using booksAPI.Entities;

namespace booksAPI.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context) { }
    }
}
