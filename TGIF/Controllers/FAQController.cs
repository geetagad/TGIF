using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGIF.Models;

namespace TGIF.Controllers
{
    public class FAQController : Controller
    {
        private TGIFDBContext db = new TGIFDBContext();

        //
        // GET: /FAQ/

        public ActionResult Index()
        {
            return View(db.FAQs.ToList());
        }

        //
        // GET: /FAQ/

        public ActionResult FAQListByType(string type = null)
        {
            ViewBag.Title= type + " FAQ";
            return View(db.FAQs.Where(r => r.Type == type).ToList());
        }

        //
        // GET: /FAQ/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /FAQ/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FAQ/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(FAQ faqmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.FAQs.Add(faqmodel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to Create FAQ. Try again, and if the problem persists see your system administrator.");
            }

            return View(faqmodel);
        }

        //
        // GET: /FAQ/Edit/5

        public ActionResult Edit(int id)
        {
            FAQ faqmodel = db.FAQs.Find(id);
            if (faqmodel == null)
            {
                return HttpNotFound();
            }

            return View(faqmodel);
        }

        //
        // POST: /FAQ/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, FAQ faqmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(faqmodel).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException)
                ModelState.AddModelError("", "Unable to Edit FAQ. Try again, and if the problem persists see your system administrator.");
            }
            return View(faqmodel);
        }

        //
        // GET: /FAQ/Delete/5
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            FAQ faqmodel = db.FAQs.Find(id);
            if (faqmodel == null)
            {
                return HttpNotFound();
            }
            return View(faqmodel);
        }

        //
        // POST: /FAQ/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAQ faqmodel = db.FAQs.Find(id);
            try
            {
                db.FAQs.Remove(faqmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(faqmodel);
            }
        }
    }
}
