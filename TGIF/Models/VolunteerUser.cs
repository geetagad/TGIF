using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TGIF.Models
{
    public class VolunteerUser
    {
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }

        [Display(Name = "School Name")]
        public string SchoolName{ get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skills { get; set; }
        public string Comment { get; set; }
       
    }
}