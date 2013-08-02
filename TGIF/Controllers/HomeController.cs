using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TGIF.Models;

namespace TGIF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to TGIF website";

            return View();
        }

        public ActionResult About() 
        {
            ViewBag.Message = "About TGIF.";

            return View();
        }

        //[Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "TGIF contact page.";

            return View();
        }

       

       
        // //[HandleError]

        //public ActionResult CalendarData()
        //{
        //    IList<CalendarEventViewModel> tasksList = new List<CalendarEventViewModel>();

        //    tasksList.Add(new CalendarEventViewModel
        //    {
        //        id = 1,
        //        title = "Google search",
        //        start = ToUnixTimespan(DateTime.Now),
        //        end = ToUnixTimespan(DateTime.Now.AddHours(4)),
        //        url = "www.google.com"
        //    });
        //    tasksList.Add(new CalendarEventViewModel
        //    {
        //        id = 1,
        //        title = "Bing search",
        //        start = ToUnixTimespan(DateTime.Now.AddDays(1)),
        //        end = ToUnixTimespan(DateTime.Now.AddDays(1).AddHours(4)),
        //        url = "www.bing.com"
        //    });

        //    return Json(tasksList, JsonRequestBehavior.AllowGet);
        //}

        //private long ToUnixTimespan(DateTime date)
        //{
        //    TimeSpan tspan = date.ToUniversalTime().Subtract(
        // new DateTime(1970, 1, 1, 0, 0, 0));

        //      return (long)Math.Truncate(tspan.TotalSeconds);
        //}
       
   

    }
}
