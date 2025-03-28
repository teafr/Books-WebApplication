using System.ComponentModel.DataAnnotations;

namespace booksAPI.Models.DatabaseModels
{
    public class UserModel : IDatabaseModel
    {
        public UserModel(int id, string username, string name, string email, string? description, string password)
        {
            Id = id;
            Username = username;
            Name = name;
            Email = email;
            Description = description;
            Password = password;
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Password { get; set; }
    }
}