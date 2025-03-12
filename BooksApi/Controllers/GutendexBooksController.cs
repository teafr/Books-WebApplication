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

            if (books == null)
            {
                return NotFound(recordNotFound);
            }

            return Ok(books);
        }

        [HttpGet("{id:int:min(1)}/fulltext")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
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
