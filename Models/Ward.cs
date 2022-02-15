using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uzbekistan_Social_Fund.Models
{
    public class Ward
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Ward")]
        [StringLength(70, ErrorMessage ="Cannot exceed 70 character")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Sub County")]
        public int SubCountyId { get; set; }

        [ForeignKey("SubCountyId")]
        public virtual SubCounty SubCounty { get; set; }
    }
}
