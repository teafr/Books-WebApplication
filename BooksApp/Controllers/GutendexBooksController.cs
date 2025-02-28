using booksAPI.Controllers;
using booksAPI.Models.DatabaseModels;
using booksAPI.Models.GutendexModels;
using booksAPI.Repositories;
using booksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GutendexBooksController : BaseController
    {
        private readonly IGutendexService _gutendexService;

        public GutendexBooksController(IGutendexService gutendexService, ILogger<GutendexBooksController> logger) : base(logger)
        {
            _gutendexService = gutendexService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {
            List<GutendexBook>? books = await _gutendexService.SearchBooksAsync("search", query);

            if (books == null)
            {
                return NotFound(recordNotFound);
            }

            return Ok(books);
        }

        [HttpGet("{id}/fulltext")]
        public async Task<IActionResult> GetFullTextUrl(int id)
        {
            return await ExceptionHandle(async () =>
            {
                string? txtUrl = await _gutendexService.GetTxtUrlAsync(id);

                if (txtUrl == null)
                {
                    return NotFound(recordNotFound);
                }

                return Ok(new { txtUrl });
            });
        }
    }
}
