using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uzbekistan_Social_Fund.Models
{
    public class Applicant
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(100, ErrorMessage ="Cannot Exceed 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Cannot Exceed 100 characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Cannot Exceed 100 characters")]
        public string Surname { get; set; } 
        
        [Required]
        
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public  DateTime DateOfBirth{ get; set; }

        [Required]
        [DefaultValue(false)]
        [Display(Name ="Are you Married?")]
        public bool IsMarried { get; set; }

        [Required]
        public string PINFLNumber { get; set; }

        public int WardId { get; set; }

        [Display(Name ="Postal Address")]
        public string PostalAddress { get; set; }

        [Display(Name ="Physical Address")]
        public string PhysicalAddress {get; set; }

        [Display(Name ="Telephone")]
        public string TelephoneContacts { get; set; }   

        [Required]
        [Key]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }    



    }
}
