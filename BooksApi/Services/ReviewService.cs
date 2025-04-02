using booksAPI.Entities;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace booksAPI.Services
{
    public class ReviewService : AbstractCrudService<ReviewModel, Review>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;

        public ReviewService(IRepository<Review> reviewRepository, IRepository<Book> bookRepository, IRepository<User> userRepository) : base(reviewRepository)
        {
            this._bookRepository = bookRepository;
            this._userRepository = userRepository;
        }

        public override async Task<ReviewModel> CreateAsync(ReviewModel review)
        {
            var entity = GetEntityObject(review);
            await InitializeObjectsOfReview(entity);
            return GetModelObject(await _repository.CreateAsync(entity));
        }

        public override async Task UpdateAsync(ReviewModel reviewToUpdate)
        {
            var existingReview = await _repository.GetByIdAsync(reviewToUpdate.Id);

            existingReview!.Id = reviewToUpdate.Id;
            existingReview.Rating = reviewToUpdate.Rating;
            existingReview.Text = reviewToUpdate.Text;
            existingReview.UserId = reviewToUpdate.User.Id;
            existingReview.BookId = reviewToUpdate.Book.Id;

            await InitializeObjectsOfReview(existingReview);
            await _repository.UpdateAsync(existingReview);
        }

        private async Task InitializeObjectsOfReview(Review review)
        {
            await InitializeUser(review);
            await InitializeBook(review);
        }

        private async Task InitializeUser(Review review)
        {
            User? user = await _userRepository.GetByIdAsync(review.UserId);
            if (user != null)
            {
                review.User = user;
            }
        }

        private async Task InitializeBook(Review review)
        {
            Book? book = await _bookRepository.GetByIdAsync(review.BookId);
            if (book != null)
            {
                review.Book = book;
            }
        }

        protected override ReviewModel GetModelObject(Review entity)
        {
            return new ReviewModel(entity);
        }

        protected override Review GetEntityObject(ReviewModel model)
        {
            return new Review()
            {
                Id = model.Id,
                Text = model.Text,
                Rating = model.Rating,
                UserId = model.User.Id,
                BookId = model.Book.Id,
                Book = new Book() { Id = model.Book.Id, Name = model.Book.Name },
                User = new User() { Id = model.User.Id, Username = model.User.Username, Name = model.User.Name, Email = model.User.Email, Description = model.User.Description, Password = model.User.Password }
            };
        }
    }
}
