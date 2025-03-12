using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace booksAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly object recordNotFound = new
        {
            statusCode = 404,
            message = "Record not found"
        };

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

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value)
        {
            _logger.LogWarning("Record was not found by user. Response: {NotFoundInfo}", recordNotFound);
            return base.NotFound(value);
        }

        public override NoContentResult NoContent()
        {
            _logger.LogInformation("Response contain no content.");
            return base.NoContent();
        }
    }
}
