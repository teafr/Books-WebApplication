using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace web_api_for_books_app.Services
{
    public class UserService : ICrudService<User>
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> user)
        {
            this._userRepository = user;
        }
        public async Task<List<User>?> GetAsync()
        {
            return await _userRepository.GetAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateAsync(User review)
        {
            return await _userRepository.CreateAsync(review);
        }

        public async Task UpdateAsync(User review)
        {
            await _userRepository.UpdateAsync(review);
        }

        public async Task DeleteAsync(User review)
        {
            await _userRepository.DeleteAsync(review);
        }
    }
}
