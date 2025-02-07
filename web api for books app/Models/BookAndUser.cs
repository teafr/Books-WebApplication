using System.ComponentModel.DataAnnotations.Schema;
using web_api_for_books_app.Enums;

namespace web_api_for_books_app.Models
{
    [Table("m2m_books_users")]
    public class BookAndUser
    {
        [ForeignKey("User")]
        [Column("user_id")]
        public required int UserId { get; set; }

        [ForeignKey("Book")]
        [Column("book_id")]
        public required int BookId { get; set; }

        [Column("status")]
        public Status Status { get; set; }

        public required User User { get; set; }

        public required Book Book { get; set; }
    }
}
