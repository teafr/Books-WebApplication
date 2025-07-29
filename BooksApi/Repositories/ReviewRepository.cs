using booksAPI.Contexts;
using booksAPI.Entities;

namespace booksAPI.Repositories
{
    public class ReviewRepository : BaseRepository<ReviewEntity>
    {
        public ReviewRepository(LibraryContext context) : base(context) { }
    }
}
