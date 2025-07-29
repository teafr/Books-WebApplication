using booksAPI.Services;

namespace booksAPI.Models
{
    public class BookFactory
    {
        private readonly IGutendexService gutendexService;
        private readonly IReviewService reviewService;

        public BookFactory(IGutendexService gutendexService, IReviewService reviewService)
        {
            this.gutendexService = gutendexService;
            this.reviewService = reviewService;
        }

        public async Task<BookModel> CreateBookModel(int bookId)
        {
            return new BookModel(await reviewService.GetReviewsByBookIdAsync(bookId), await gutendexService.GetBookByIdAsync(bookId));
        }
    }
}
