using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uzbekistan_Social_Fund.Models
{
    public class MemberEducation
    {
        
        public int Id { get; set; } 

        [Required]
        [Display(Name ="Can You read any language?")]
        [DefaultValue(false)]
        public bool LangugeProfiency { get; set; }

        [Required]
        [Display(Name = "Can you write in any language?")]
        [DefaultValue(false)]
        public bool WriteProfiency { get; set; }

        [Display(Name = "Is currently attending school?")]
        [Required]
        [DefaultValue(false)]
        public bool SchoolAttendance { get; set; }

        [Display(Name = "If attending, what level is attending ?")]
        [DefaultValue(false)]
        public string SchoolLevel { get; set; } 
        [Display(Name = "If not currently attending school, has ever attended school?")]
        [DefaultValue(false)]
        public bool HasAttendedSchool { get; set; }

        [Display(Name = "If ever attended, what was the highest level completed?")]
        public string HighestSchoolLevel { get; set; }  

        [Required]
        [DisplayName("Member Id")]
        public int HouseMemberId { get; set; }

        [ForeignKey("HouseMemberId")]
        public virtual HouseMember HouseMember { get; set; }    
    }

}
