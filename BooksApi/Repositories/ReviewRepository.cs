using booksAPI.Contexts;
using booksAPI.Data;

namespace booksAPI.Repositories
{
    public class ReviewRepository : BaseRepository<ReviewEntity>
    {
        public ReviewRepository(LibraryContext context) : base(context) { }
    }
}
