using Hangfire.Mailer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Hangfire.Mailer.Controllers
{
    public class MedicalController : ApiController
    {
        private MailerDbContext db = new MailerDbContext();

        // GET: /Users/

        public ActionResult Index()
        {
            return View(db.Medical.ToList());
        }

        private ActionResult View(List<Medical> medicals)
        {
            throw new NotImplementedException();
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Medical medical = db.Medical.Find(id);
            if (medical == null)
            {
                return HttpNotFound();
            }
            return View(medical);
        }

        private ActionResult View(Medical medical)
        {
            throw new NotImplementedException();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        //
        // POST: /Users/Create

        [System.Web.Http.HttpPost]
        public ActionResult Create(Medical medical)
        {
            if (ModelState.IsValid)
            {
                medical.CreateDate = DateTime.Today;
                db.Medical.Add(medical);
                db.SaveChanges();

                //BackgroundJob.Enqueue(() => RemainderFunc.NotifyNewRemainder(medical.PatientId, medical.CronExpress));
                //נשלח בתדירות קרון
                var JobName = medical.PatientId.ToString() + medical.CronExpress;
                RecurringJob.AddOrUpdate(JobName, () => RemainderFunc.NotifyNewRemainder(medical.PatientId, medical.CronExpress), medical.CronExpress);

                return RedirectToAction("Index");
            }

            return View(medical);
        }

        private ActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Medical medical = db.Medical.Find(id);
            if (medical == null)
            {
                return HttpNotFound();
            }
            return View(medical);
        }

        //
        // POST: /Users/Edit/5

        [System.Web.Http.HttpPost]
        public ActionResult Edit(Medical medical)
        {
            if (ModelState.IsValid)
            {
                medical.UpdateDate = DateTime.Today;
                db.Entry(medical).State = EntityState.Modified;
                db.SaveChanges();

                var JobName = medical.PatientId.ToString() + medical.CronExpress;
                RecurringJob.AddOrUpdate(JobName, () => RemainderFunc.NotifyNewRemainder(medical.PatientId, medical.CronExpress), medical.CronExpress);

                return RedirectToAction("Index");
            }
            return View(medical);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id)
        {
            Medical medical = db.Medical.Find(id);
            if (medical == null)
            {
                return HttpNotFound();
            }
            return View(medical);
        }

        //
        // POST: /Users/Delete/5

        [System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Medical medical = db.Medical.Find(id);
            db.Medical.Remove(medical);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult ListPatientMedicalByMedicalCode(int IdPatient)
        {
            if (IdPatient == null)
            {
                return HttpNotFound();
            }
            return View(db.Medical.Where(a => a.PatientId.Equals(IdPatient)).ToList());
        }

    }
}
