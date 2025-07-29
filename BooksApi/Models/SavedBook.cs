using booksAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace booksAPI.Models
{
    [Table("SavedBooks")]
    public class SavedBook
    {
        [Column("UserId")]
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;

        [Column("BookId")]
        public int BookId { get; set; }

        [Column("Status")]
        [Range(0, 2, ErrorMessage = "Status must be between 0 and 2.")]
        public Status Status{ get; set; }

        public ApplicationUser User { get; set; }
    }
}
