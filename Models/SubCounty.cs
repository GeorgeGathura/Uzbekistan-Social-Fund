using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uzbekistan_Social_Fund.Models
{
    public class SubCounty
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name ="Sub-County")]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [Display(Name ="County")]
        public int CountyId { get; set; }   

        [ForeignKey("CountyId")]
        public virtual County County { get; set; }
    }
}
