using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;
using booksAPI.Entities;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : CrudController<ReviewModel>
    {
        public ReviewsController(ICrudService<ReviewModel> service, ILogger<ReviewsController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Post(ReviewModel item)
        {
            if (item.User.Id < 1 || item.Book.Id < 1)
            {
                return NotFound(childNotFound);
            }

            return await base.Post(item);
        }
    }
}
