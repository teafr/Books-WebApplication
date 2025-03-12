using booksAPI.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : CrudController<Review>
    {
        public ReviewsController(ICrudService<Review> service, ILogger<ReviewsController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Post(Review review)
        {
            return await ExceptionHandle(async () =>
            {
                if (review is null)
                {
                    return GetBadRequestResponse();
                }

                if (review.User is null && review.Book is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var createdReview = await _service.CreateAsync(review);
                return CreatedAtAction(nameof(Post), createdReview);
            });
        }

        public override async Task<IActionResult> Put(Review reviewToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                if (reviewToUpdate is null)
                {
                    return GetBadRequestResponse();
                }

                if (reviewToUpdate.User is null && reviewToUpdate.Book is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var existingReview = await _service.GetByIdAsync(reviewToUpdate.Id);

                if (existingReview == null)
                {
                    return GetNotFoundResponse();
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
