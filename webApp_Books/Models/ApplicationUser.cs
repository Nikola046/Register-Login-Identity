using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webApp_Books.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = "";
        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = "";
    }
}
