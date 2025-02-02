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
        public string Name { get; set; }

        [ForeignKey("Author")]
        [Column("author_id")]
        [Required]
        public int AuthorId { get; set; }

        [JsonIgnore]
        public Author Author { get; set; }

        [JsonIgnore]
        public List<Review>? Reviews { get; set; }
    }
}
