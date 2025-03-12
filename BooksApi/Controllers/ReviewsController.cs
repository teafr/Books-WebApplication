using booksAPI.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : CrudController<Review>
    {
        public ReviewsController(ICrudService<Review> service, ILogger<ReviewsController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Put(Review reviewToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingReview = await _service.GetByIdAsync(reviewToUpdate.Id);

                if (existingReview == null)
                {
                    return NotFound(recordNotFound);
                }

                existingReview.Id = reviewToUpdate.Id;
                existingReview.User = reviewToUpdate.User!;
                existingReview.Book = reviewToUpdate.Book;
                existingReview.Text = reviewToUpdate.Text;
                existingReview.Rating = reviewToUpdate.Rating;

                await _service.UpdateAsync(existingReview);
                return NoContent();
            });
        }
    }
}
