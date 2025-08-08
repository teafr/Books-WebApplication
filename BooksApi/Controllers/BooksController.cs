using booksAPI.Models;
using booksAPI.Models.GutendexModels;
using booksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : BaseController
    {
        private readonly IGutendexService _gutendexService;
        private readonly IReviewService reviewService;

        public BooksController(IGutendexService gutendexService, IReviewService reviewService, ILogger<BooksController> logger) : base(logger)
        {
            _gutendexService = gutendexService;
            this.reviewService = reviewService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllBooks()
        {
            return await ExceptionHandle(async () =>
            {
                return Ok(await _gutendexService.GetAllBooksAsync());
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetBookById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                return Ok(await _gutendexService.GetBookByIdAsync(id));
            });
        }

        //[HttpGet("sortBy/{sort}/search")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[Produces(MediaTypeNames.Application.Json)]
        //public async Task<IActionResult> SearchAndSortBooks([FromQuery] string query, string sort)
        //{
        //    return Ok(await _gutendexService.SearchBooksAsync(query, sort));
        //}

        [HttpGet("{id:int:min(1)}/text")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetText(int id)
        {
            return await ExceptionHandle(async () =>
            {
                string? text = await _gutendexService.GetFullTextByBookIdAsync(id);
                return text == null ? NotFound() : Ok(text);
            });
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviews(int id)
        {
            return await ExceptionHandle(async () =>
            {
                return Ok(await reviewService.GetReviewsByBookIdAsync(id));
            });
        }
    }
}
