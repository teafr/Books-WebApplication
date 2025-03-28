using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;
using booksAPI.Entities;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : CrudController<Review>
    {
        public ReviewsController(ICrudService<Review> service, ILogger<ReviewsController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Post(Review item)
        {
            if (item.UserId == 0 || item.BookId == 0)
            {
                return NotFound(childNotFound);
            }

            return await base.Post(item);
        }
    }
}
