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
    public class UserController : ApiController
    {
        private MailerDbContext db = new MailerDbContext();

        // GET: /Users/

        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        private ActionResult View(List<User> user)
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
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
           

        }

        private ActionResult View(User login)
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
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.CreateDate = DateTime.Today;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
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
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [System.Web.Http.HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
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
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
