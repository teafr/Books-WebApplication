using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using web_api_for_books_app.Enums;

namespace web_api_for_books_app.Models
{
    [Table("m2m_books_users")]
    public class BookAndUser
    {
        [Required]
        [ForeignKey("Book")]
        [Column("book_id")]
        public int BookId { get; set; }

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("status")]
        public Status Status { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
