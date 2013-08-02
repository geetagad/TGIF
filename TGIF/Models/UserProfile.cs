using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TGIF.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name="User Email")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Security Code")]
        public string SecurityCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        //[Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Home Phone format is not valid.")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        public virtual ICollection<UserEvent> UserEvents { get; set; }
        //public virtual Volunteer Volunteer { get; set; }
        
    }
}