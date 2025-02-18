using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Models;
using web_api_for_books_app.Repositories;

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IRepository<User> userRepository, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var users = await _userRepository.GetAsync();
                return Ok(users);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                return Ok(user);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return await ExceptionHandle(async () =>
            {
                var createdUser = await _userRepository.CreateAsync(user);
                return CreatedAtAction(nameof(Post), createdUser);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(User UserToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _userRepository.GetByIdAsync(UserToUpdate.Id);

                if (user == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                user.Name = UserToUpdate.Name;
                user.Email = UserToUpdate.Email;
                user.Description = UserToUpdate.Description;
                user.Username = UserToUpdate.Username;

                await _userRepository.UpdateAsync(user);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                await _userRepository.DeleteAsync(user);
                return NoContent();
            });
        }

        private async Task<IActionResult> ExceptionHandle(Func<Task<IActionResult>> function)
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
