using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace booksAPI.Services
{
    public class ReviewService : ICrudService<Review>
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;

        public ReviewService(IRepository<Review> repository, IRepository<Book> book, IRepository<User> user)
        {
            this._reviewRepository = repository;
            this._bookRepository = book;
            this._userRepository = user;
        }
        public async Task<List<Review>?> GetAsync()
        {
            return await _reviewRepository.GetAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<Review> CreateAsync(Review review)
        {
            await InitializeObjectsOfReview(review);
            return await _reviewRepository.CreateAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            await InitializeObjectsOfReview(review);
            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteAsync(Review review)
        {
            await _reviewRepository.DeleteAsync(review);
        }

        private async Task InitializeObjectsOfReview(Review review)
        {
            await InitializeUser(review);
            await InitializeBook(review);
        }

        private async Task InitializeUser(Review review)
        {
            if (review.ReviwerId != 0)
            {
                User? user = await _userRepository.GetByIdAsync(review.ReviwerId);
                if (user != null)
                {
                    review.User = user;
                }
            }
        }

        private async Task InitializeBook(Review review)
        {
            if (review.BookId != 0)
            {
                Book? book = await _bookRepository.GetByIdAsync(review.BookId);
                if (book != null)
                {
                    review.Book = book;
                }
            }
        }
    }
}
