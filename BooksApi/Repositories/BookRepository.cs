using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context) { }
    }
}
