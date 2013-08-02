using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TGIF.Models
{
    public class CalendarEventViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public string url { get; set; }
    }
   
}