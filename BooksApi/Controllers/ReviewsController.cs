using booksAPI.Models;
using booksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : BaseController
    {
        private readonly IReviewService service;

        public ReviewsController(IReviewService service, ILogger<ReviewsController> logger) : base(logger)
        {
            this.service = service;
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var item = await service.GetReviewByIdAsync(id);
                return item is null ? NotFound(recordNotFound) : Ok(item);
            });
        }

        [HttpPost("book/{bookId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Post(int bookId, ReviewModel item)
        {
            return await ExceptionHandle(async () =>
            {
                return CreatedAtAction(nameof(Post), await service.AddReviewAsync(bookId, item));
            });
        }


        [HttpPut("{reviewId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public virtual async Task<IActionResult> Put(int reviewId, ReviewModel itemToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingItem = await service.GetReviewByIdAsync(itemToUpdate.Id);
                if (existingItem is null)
                {
                    return NotFound(recordNotFound);
                }

                await service.UpdateReviewAsync(reviewId, itemToUpdate);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var item = await service.GetReviewByIdAsync(id);
                if (item is null)
                {
                    return NotFound(recordNotFound);
                }

                if (await service.DeleteReviewAsync(id))
                {
                    _logger.LogInformation($"Review with ID {id} deleted successfully.");
                    return NoContent();
                }
                else
                {
                    _logger.LogWarning($"Failed to delete review with ID {id}.");
                    throw new InvalidOperationException("Failed to delete the review.");
                }
            });
        }
    }
}
