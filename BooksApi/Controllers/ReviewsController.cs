using booksAPI.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReviewsController : CrudController<Review>
    {
        public ReviewsController(ICrudService<Review> service, ILogger<ReviewsController> logger) : base(service, logger) { }
    }
}
