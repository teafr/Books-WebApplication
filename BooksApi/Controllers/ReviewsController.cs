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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () => Ok(await service.GetAllReviewsAsync()));
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () => Ok((await service.GetReviewByIdAsync(id)) ?? throw new KeyNotFoundException($"Review with ID {id} not found.")));
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
                item.ReviewDate = DateTime.UtcNow;
                return CreatedAtAction(nameof(Post), await service.AddReviewAsync(bookId, item));
            });
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public virtual async Task<IActionResult> Put(int id, ReviewModel itemToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                itemToUpdate.Id = id;
                await service.UpdateReviewAsync(itemToUpdate);
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
                await service.DeleteReviewAsync(id);
                return NoContent();
            });
        }
    }
}
