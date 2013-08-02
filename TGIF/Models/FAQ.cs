using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TGIF.Models
{
    public class FAQ
    {
        public FAQ()
        {
            
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FAQId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string Question { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string Answer{ get; set; }

        [StringLength(15)]
        public string Type { get; set; }
    }
}