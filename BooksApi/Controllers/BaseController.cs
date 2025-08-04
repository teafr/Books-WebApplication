using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace booksAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        protected BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> ExceptionHandle(Func<Task<IActionResult>> function)
        {
            try
            {
                return await function();
            }
            catch (ArgumentNullException argumentNullException)
            {
                _logger.LogWarning(argumentNullException, "{Message}", new { argumentNullException.Message });
                return BadRequest(new
                {
                    statusCode = StatusCodes.Status400BadRequest,
                    message = argumentNullException.Message
                });
            }
            catch (KeyNotFoundException keyNotFoundException)
            {
                _logger.LogWarning(keyNotFoundException, "{Message}", new { keyNotFoundException.Message });
                return NotFound(new
                {
                    statusCode = StatusCodes.Status404NotFound,
                    message = keyNotFoundException.Message
                });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "{Message}", new { exception.Message });

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = exception.Message
                });
            }
        }

        public override NoContentResult NoContent()
        {
            _logger.LogInformation("Response contain no content.");
            return base.NoContent();
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            _logger.LogInformation("Record(s) was/were found by user. Response: {Response}", value);
            return base.Ok(value);
        }
    }
}
