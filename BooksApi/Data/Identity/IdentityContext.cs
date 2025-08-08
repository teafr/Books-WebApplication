using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Data.Identity
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        public DbSet<SavedBookEntity> SavedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SavedBookEntity>().HasKey(sb => new { sb.BookId, sb.UserId });
            builder.Entity<SavedBookEntity>().HasOne(user => user.User).WithMany(u => u.SavedBooks).HasForeignKey(b => b.UserId);
            builder.Entity<ApplicationUser>().Property(LoginUser => LoginUser.Name);
        }
    }
}
