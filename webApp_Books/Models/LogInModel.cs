using System.ComponentModel.DataAnnotations;

namespace webApp_Books.Models
{
    public class LogInModel
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
