using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : BaseController
    {
        private readonly IBookService service;

        public BooksController(IBookService service, ILogger<BooksController> logger) : base(logger)
        {
            this.service = service;
        }
    }
}
