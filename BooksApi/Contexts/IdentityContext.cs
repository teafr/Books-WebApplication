using booksAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Contexts
{
    public class IdentityContext : IdentityDbContext<LoginUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LoginUser>().Property(LoginUser => LoginUser.Name);

            //builder.HasDefaultSchema("identity");
        }
    }
}
