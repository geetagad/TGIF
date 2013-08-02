using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using TGIF.Models;
using WebMatrix.WebData;

namespace TGIF.Controllers
{
    public class VolunteerController : Controller
    {
        private TGIFDBContext db = new TGIFDBContext();

        //
        // GET: /Volunteer/

        [Authorize(Roles = "Administrator")]
        public ActionResult Index(string searchTerm = null)
        {
            var model = from r in db.Volunteers
                        join s in db.UserProfiles
                        on r.UserId equals s.UserId
                        where (searchTerm == null || s.SchoolName.StartsWith(searchTerm))
                        orderby r.UserId
                        select new VolunteerUser
                        {
                            ParentName = s.ParentName,
                            SchoolName = s.SchoolName,
                            Email = s.UserName,
                            Phone = s.HomePhone,
                            Skills = r.Skills,
                            Comment = r.Comment
                        };
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult ExportVolunteerList()
        {
            var model = from r in db.Volunteers
                        join s in db.UserProfiles
                        on r.UserId equals s.UserId
                        orderby r.UserId
                        select new VolunteerUser
                        {
                            ParentName = s.ParentName,
                            SchoolName = s.SchoolName,
                            Email = s.UserName,
                            Phone = s.HomePhone,
                            Skills = r.Skills,
                            Comment = r.Comment
                        };

            GridView gv = new GridView();
            gv.DataSource = model.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=TGIFVolunteerlist.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }

        //
        // GET: /Event/Details/5
         [Authorize]
        public ActionResult Details(int id = 0)
        {
            if ( db.Volunteers.Where(r => r.UserId == id).Count() > 0)
            {
                Volunteer model = db.Volunteers.Where(r => r.UserId == id).First();
                return RedirectToAction("Edit", new { id = model.VolunteerId });
            }
            else
            {
                return RedirectToAction("Create");
            }
            
        }

        //
        // GET: /Event/Create
         [Authorize]
        public ActionResult Create()
        {
            Volunteer volunteermodel = new Volunteer();
            volunteermodel.UserId = WebSecurity.GetUserId(User.Identity.Name);
            return View(volunteermodel);
        }

        //
        // POST: /Event/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
         public ActionResult Create(Volunteer volunteermodel)
        {
            if (ModelState.IsValid)
            {
                db.Volunteers.Add(volunteermodel);
                db.SaveChanges();
                return RedirectToAction("UserDetail", "Account", new { id = volunteermodel.UserId });
            }

            return View(volunteermodel);
        }

        //
        // GET: /Volunteer/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Volunteer volunteermodel = db.Volunteers.Find(id);
            if (volunteermodel == null)
            {
                return HttpNotFound();
            }
            return View(volunteermodel);
        }

        //
        // POST: /Volunteer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Volunteer volunteermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteermodel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserDetail", "Account", new { id = volunteermodel.UserId });
            }
            return View(volunteermodel);
        }

        //
        // GET: /Volunteer/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Volunteer volunteermodel = db.Volunteers.Find(id);
            if (volunteermodel == null)
            {
                return HttpNotFound();
            }
            return View(volunteermodel);
        }

        //
        // POST: /Event/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteermodel = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteermodel);
            db.SaveChanges();
            return RedirectToAction("UserDetail", "Account", new { id = volunteermodel.UserId });
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
