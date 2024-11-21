using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_for_books_app.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime DateOfPublication { get; set; }

        //public List<Review> Reviews { get; set; }
    }
}
