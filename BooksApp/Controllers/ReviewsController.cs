using booksAPI.Controllers;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Services;

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService, ILogger<ReviewsController> logger) : base(logger)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var reviews = await _reviewService.GetAsync();
                return Ok(reviews);
            });
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var review = await _reviewService.GetByIdAsync(id);

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
                var createdReview = await _reviewService.CreateAsync(review);
                return CreatedAtAction(nameof(Post), createdReview);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Review reviewToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _reviewService.GetByIdAsync(reviewToUpdate.Id);

                if (existingReview == null)
                {
                    return NotFound(recordNotFound);
                }

                existingReview.Id = reviewToUpdate.Id;
                existingReview.Text = reviewToUpdate.Text;
                existingReview.User = reviewToUpdate.User;
                existingReview.Rating = reviewToUpdate.Rating;
                existingReview.Book = reviewToUpdate.Book;

                await _reviewService.UpdateAsync(existingReview);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _reviewService.GetByIdAsync(id);

                if (existingReview == null)
                {
                    return NotFound(recordNotFound);
                }

                await _reviewService.DeleteAsync(existingReview);
                return NoContent();
            });
        }
    }
}
