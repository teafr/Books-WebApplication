using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly LibraryContext Context;
        public UserRepository(LibraryContext context)
        {
            Context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await Context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAsync()
        {
            return await Context.Users.ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            Context.Update(user);
            await Context.SaveChangesAsync();
        }
    }
}
