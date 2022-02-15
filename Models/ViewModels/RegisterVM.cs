using System.ComponentModel.DataAnnotations;

namespace Uzbekistan_Social_Fund.Models.ViewModels
{
    public class RegisterVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "Cannot Exceed 70 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70, ErrorMessage ="Cannot Exceed 70 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }   

        [Required]
        [Display(Name ="Role")]
        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Both Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }
        

    }
}
