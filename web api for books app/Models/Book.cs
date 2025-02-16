using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public required string Name { get; set; }

        [JsonIgnore]
        public List<Review>? Reviews { get; set; } = new List<Review>();

        [JsonIgnore]
        [NotMapped]
        public List<BookAndUser> UsersSaved { get; set; }
    }
}
