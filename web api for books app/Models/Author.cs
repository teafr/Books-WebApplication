using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models
{
    [Table("authors")]
    public class Author
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public required string Name { get; set; }

        [JsonIgnore]
        public List<Book>? Books { get; set; }

    }
}
