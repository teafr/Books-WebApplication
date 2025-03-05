using booksAPI.Controllers;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController
    {
        private readonly IRepository<Review> _repository;

        public ReviewsController(IRepository<Review> repository, ILogger<ReviewsController> logger) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var reviews = await _repository.GetAsync();
                return Ok(reviews);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var review = await _repository.GetByIdAsync(id);

                if (review == null)
                {
                    return NotFound(recordNotFound);
                }

                return Ok(review);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Review review)
        {
            return await ExceptionHandle(async () =>
            {
                var createdReview = await _repository.CreateAsync(review);
                return CreatedAtAction(nameof(Post), createdReview);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Review reviewToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _repository.GetByIdAsync(reviewToUpdate.Id);

                if (existingReview == null)
                {
                    return NotFound(recordNotFound);
                }

                existingReview.Id = reviewToUpdate.Id;
                existingReview.Text = reviewToUpdate.Text;
                existingReview.User = reviewToUpdate.User;
                existingReview.Rating = reviewToUpdate.Rating;
                existingReview.Book = reviewToUpdate.Book;

                await _repository.UpdateAsync(existingReview);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _repository.GetByIdAsync(id);

                if (existingReview == null)
                {
                    return NotFound(recordNotFound);
                }

                await _repository.DeleteAsync(existingReview);
                return NoContent();
            });
        }
    }
}
