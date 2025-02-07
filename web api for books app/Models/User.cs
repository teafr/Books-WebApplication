using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public required string Username { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [EmailAddress]
        [Column("email")]
        public required string Email { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [JsonIgnore]
        public List<Review>? Reviews { get; set; } = new List<Review>();

        [JsonIgnore]
        [NotMapped]
        public List<BookAndUser>? SavedBooks { get; set; } = new List<BookAndUser>();
    }
}
