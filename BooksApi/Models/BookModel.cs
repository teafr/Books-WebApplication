using booksAPI.Models.GutendexModels;

namespace booksAPI.Models
{
    public class BookModel
    {
        public BookModel(ICollection<ReviewModel> reviews, GutendexBook gutendexBook)
        {
            GutendexBook = gutendexBook;
            Reviews = reviews;
        }

        public GutendexBook? GutendexBook { get; set; }

        public ICollection<ReviewModel>? Reviews { get; set; }
    }
}