using booksAPI.Entities;
using booksAPI.Helpers;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace booksAPI.Services
{
    public class UserService : AbstractCrudService<UserModel, User>
    {
        public UserService(IRepository<User> repository) : base(repository) { }

        public override async Task UpdateAsync(UserModel userToUpdate)
        {
            var existingUser = await _repository.GetByIdAsync(userToUpdate.Id);
            //existingUser = GetEntityObject(userToUpdate);

            existingUser!.Id = userToUpdate.Id;
            existingUser.Username = userToUpdate.Username;
            existingUser.Name = userToUpdate.Name;
            existingUser.Email = userToUpdate.Email;
            existingUser.Description = userToUpdate.Description;
            existingUser.Password = Encrypter.Encrypt(userToUpdate.Password);

            await _repository.UpdateAsync(existingUser);
        }

        protected override UserModel GetModelObject(User user)
        {
            return new UserModel(user.Id, user.Username, user.Name, user.Email, user.Description, user.Password);
        }

        protected override User GetEntityObject(UserModel user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Description = user.Description,
                Password = Encrypter.Encrypt(user.Password)
            };
        }
    }
}
