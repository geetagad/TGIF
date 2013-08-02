using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TGIF.Models
{
    public class UserEvent
    {
        public UserEvent()
        {
            
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserEventId { get; set; }

        [Required]
        [Display(Name="Number of Attendees")]
        public int Attendees { get; set; }

        [Required]
        [Display(Name = "Registartion Date")]
        public DateTime RegistrationDate { get; set; }

        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }

    }
}