using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webApp_Books.Models
{
    public class Book
    {
        [Required(ErrorMessage = "BookID is required")]
        public int BookID { get; set; }

        [DisplayName("The name of the book")]
        [Required(ErrorMessage = "The name of the book is required")]
        public string BookName { get; set; } = "";

        [DisplayName("Writer")]
        [Required(ErrorMessage = "Writer name is required")]
        public string Writer { get; set; } = "";

        [DisplayName("Number of pages")]
        [Required(ErrorMessage = "Number of pages is required")]
        public string NumberOfPages { get; set; } = "";
    }
}
