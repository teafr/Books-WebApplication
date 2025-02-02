using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_for_books_app.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }
        
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }
    }
}
