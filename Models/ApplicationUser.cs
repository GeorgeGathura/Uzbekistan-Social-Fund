using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Uzbekistan_Social_Fund.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [StringLength(70, ErrorMessage = "Cannot Exceed 70 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(70,ErrorMessage ="Cannot Exceed 70 characters")]
        public string LastName { get; set; }
    }
}
