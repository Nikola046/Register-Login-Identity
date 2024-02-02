using System.ComponentModel.DataAnnotations;

namespace webApp_Books.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(256)]
        public string UserName { get; set; } = "";
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = "";
        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = "";
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The password must be at least {2} and at max {1} characters long",
        MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
