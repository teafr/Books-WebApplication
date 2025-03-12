using booksAPI.Helpers;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace booksAPI.Services
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

        public async Task<User> CreateAsync(User user)
        {
            user.Password = Encrypter.Encrypt(user.Password);
            return await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(User existingUser, User userToUpdate)
        {
            existingUser.Name = userToUpdate.Name;
            existingUser.Email = userToUpdate.Email;
            existingUser.Description = userToUpdate.Description;
            existingUser.Username = userToUpdate.Username;
            existingUser.Password = Encrypter.Encrypt(userToUpdate.Password);

            await _userRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteAsync(user);
        }
    }
}
