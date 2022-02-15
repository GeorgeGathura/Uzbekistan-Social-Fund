using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uzbekistan_Social_Fund.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DefaultValue(false)]
        public bool RememberMe { get; set;}
    }
}
