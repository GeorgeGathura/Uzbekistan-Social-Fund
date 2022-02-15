using System.ComponentModel.DataAnnotations;

namespace Uzbekistan_Social_Fund.Models
{
    public class County
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70, ErrorMessage ="Cannot exceed 70 characters")]
        [Display(Name ="County")]
        public string Name { get; set; }
    }
}
