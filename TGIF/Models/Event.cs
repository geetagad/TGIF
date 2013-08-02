using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebMatrix.WebData;



namespace TGIF.Models
{
    [Table("Event")]
    public class Event : IValidatableObject
    {
        public Event()
        {
            
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Presenter { get; set; }

        [DataType(DataType.MultilineText)]
        public string Introduction { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Reporting Start Date")]
        public DateTime ReportingStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Reporting End Date")]
        public DateTime ReportingEndDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        public string Location { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        public string Eligibility { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Start Date")]
        public DateTime RegistrationBeginDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration End Date")]
        public DateTime RegistrationEndDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Cancellation Date")]
        public DateTime CancellationDate { get; set; }

        //[Required]
        [DataType(DataType.Currency)]
        public int Fee { get; set; }

        [DataType(DataType.MultilineText)]
        public string Conclusion { get; set; }

        public string CreatedBy { get; set; }

        public virtual ICollection<UserEvent> UserEvents { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReportingStartDate > ReportingEndDate)
            {
                yield return new ValidationResult("Reporting Start Date can not be greater than  Reporting EndDate");
            }
            else if (RegistrationBeginDate > RegistrationEndDate)
            {
                yield return new ValidationResult("Registration Start Date can not be greater than  Registration End Date");
            }
            else if (RegistrationBeginDate > ReportingStartDate)
            {
                yield return new ValidationResult("Registration Start Date can not be greater than  Reporting Start Date");
            }
            else if (CancellationDate > RegistrationEndDate)
            {
                yield return new ValidationResult("Cancellation Date can not be greater than  Registration End Date");
            }

        }

    }

    
    
}