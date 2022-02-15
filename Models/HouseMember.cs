using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uzbekistan_Social_Fund.Models
{
    public class HouseMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Cannot Exceed 30 characters")]
        public string IDNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime DateOfBirth { get; set; }

        [Required]
        public string Relationship { get; set; }
        [Required]
        [Display(Name ="Applicant")]
        public int ApplicantId { get; set; }

        [ForeignKey("AppliantId")]
        public virtual Applicant Applicant { get; set; }

    }
}
