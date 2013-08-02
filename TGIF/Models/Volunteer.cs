using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGIF.Models
{
    public class Volunteer
    {
        public Volunteer() 
        {
            //VolunteerUser.UserId = 
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VolunteerId { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        public string Skills { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(150)]
        public string Comment { get; set; }


        //[Key, ForeignKey("UserProfile")]
        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }
    }
    
 }