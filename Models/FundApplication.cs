using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uzbekistan_Social_Fund.Models
{
    public class FundApplication
    {
        public int Id { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Benefit for a child under two years old")]
        public bool BenefitTwoYearOld { get; set; }


        [Required]
        [DefaultValue(false)]
        [Display(Name = "Benefit for families with children up to 14 years old ")]
        public bool BenefitFamilyWithTeens { get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name = "Material support for low-income families ")]
        public bool BenefitLowIncomeFamily { get; set; }

        [Required]
        [Display(Name ="Applicant")]
        public int ApplicantId { get; set; }    

        [ForeignKey("AppliantId")]
        public virtual Applicant Applicant { get; set; }
    }
}
