using Hangfire.Mailer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Hangfire.Mailer.Controllers
{
    public class SaveDataController : Controller
    {
        private MailerDbContext db = new MailerDbContext();

         // GET: /Users/

        //public ActionResult Index()
        //{
        //    return View(db.Patient.ToList());
        //}

        ////
        //// GET: /Users/Details/5

        //public ActionResult Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Patient patient = db.Patient.Find(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient);
        //}

        ////
        //// GET: /Users/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Users/Create

        //[System.Web.Http.HttpPost]
        //public ActionResult Create(Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Patient.Add(patient);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(patient);
        //}

        ////
        //// GET: /Users/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Patient patient = db.Patient.Find(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient);
        //}

        ////
        //// POST: /Users/Edit/5

        //[System.Web.Http.HttpPost]
        //public ActionResult Edit(Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(patient).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(patient);
        //}

        ////
        //// GET: /Users/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    Patient patient = db.Patient.Find(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient);
        //}

        ////
        //// POST: /Users/Delete/5

        //[System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Patient patient = db.Patient.Find(id);
        //    db.Patient.Remove(patient);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}