using booksAPI.Models.GutendexModels;
using booksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class GutendexBooksController : BaseController
    {
        private readonly IGutendexService _gutendexService;

        public GutendexBooksController(IGutendexService gutendexService, ILogger<GutendexBooksController> logger) : base(logger)
        {
            _gutendexService = gutendexService;
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {
            List<GutendexBook>? books = await _gutendexService.SearchBooksAsync("search", query);
            return books == null ? NotFound(recordNotFound) : Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                GutendexBook? book = await _gutendexService.GetBookByIdAsync(id);
                return book == null ? NotFound(recordNotFound) : Ok(book);
            });
        }

        [HttpGet("{id:int:min(1)}/fulltext")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetFullText(int id)
        {
            return await ExceptionHandle(async () =>
            {
                string? text = await _gutendexService.GetFullTextByBookIdAsync(id);
                return text == null ? NotFound(recordNotFound) : Ok(new { text });
            });
        }
    }
}
