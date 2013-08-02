using System;
using System.ComponentModel.DataAnnotations;

namespace TGIF.Models
{
    public class RegisteredUser
    {
              
        public string StudentName { get; set; }
        public string EventName { get; set; }
        public string SchoolName { get; set; }
        public string Email { get; set; }
      
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Attendees { get; set; }
    }
}