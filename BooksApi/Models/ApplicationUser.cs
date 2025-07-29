using Microsoft.AspNetCore.Identity;

namespace booksAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

        public List<SavedBook> SavedBooks { get; set; } = new List<SavedBook>();
    }
}
