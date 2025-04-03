using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace booksAPI.Models
{
    public class LoginUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
