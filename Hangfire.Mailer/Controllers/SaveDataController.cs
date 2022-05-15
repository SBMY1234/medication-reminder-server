using Hangfire.Mailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangfire.Mailer.Controllers
{
    public class SaveDataController : Controller
    {
        private readonly MailerDbContext db = new MailerDbContext();

        // GET: SaveData
        public ActionResult Index()
        {
            return View();
        }
        //public IHttpActionResult Create(Comment model)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PirteyLk pirteyLk = await db.PirteyLk.FindAsync(id);

        //    if (pirteyLk == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return HttpResponse(stat pirteyLk);
        //}
    }
}