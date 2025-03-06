using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace booksAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly object recordNotFound = new
        {
            statusCode = 404,
            message = "record not found"
        };
        protected readonly object badRequest = new
        {
            statusCode = 400,
            message = $"can't process the received object"
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
                _logger.LogError(exception, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = exception.Message
                });
            }
        }
    }
}
