using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Hosting;
using System.Web.Mvc;
using Hangfire.Mailer.Models;
using Postal;

namespace Hangfire.Mailer.Controllers
{
    public class HomeController : Controller
    {
        private readonly MailerDbContext _db = new MailerDbContext();
        //static HttpClient client = new HttpClient();

        [HttpGet]
        public ActionResult Index()
        {
            var comments = _db.Comments.OrderBy(x => x.Id).ToList();
            return View(comments);
        }

        [HttpPost]
        public ActionResult Create(Comment model)
        {
            if (ModelState.IsValid)
            {
                _db.Comments.Add(model);
                _db.SaveChanges();

                 Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("he-IL");

                //נשלח בזמן אמת
                  BackgroundJob.Enqueue(() => NotifyNewComment(model.Id));
                //נשלח בתדירות קרון
               // RecurringJob.AddOrUpdate("powerfuljob", () => NotifyNewComment(model.Id), "0 * 23 * * ?");

            }

            return RedirectToAction("Index");
        }

        public static void NotifyNewComment(int commentId)
        {
            var currentCultureName = Thread.CurrentThread.CurrentCulture.Name;
            if (currentCultureName != "he-IL")
            {
                throw new InvalidOperationException(String.Format("Current culture is {0}", currentCultureName));
            }



            try {

                ConnectYemotMashiach("https://private.call2all.co.il/ym/api/GetSession?token=J4i5uMDPdDvG9ADn");

                //טוקן - N1eBwpAyJ6qtuVPS
                //יצירת טוקן לימות משיח
                //  https://private.call2all.co.il/ym/api/Login?username=0796075824&password=0548538616&
                //{"responseStatus":"OK","token":"N1eBwpAyJ6qtuVPS","yemotAPIVersion":6}
                //תשובה שגויה
                //{"responseStatus":"FORBIDDEN","message":"user name or password do not match","yemotAPIVersion":6}
                //בדיקה אם הטוקן פעיל
                //  https://private.call2all.co.il/ym/api/GetSession?token=N1eBwpAyJ6qtuVPS
                //תשובת השרת
                // { "responseStatus":"OK","name":"0796075824","units":10.0,"unitsExpireDate":"2023-05-13","contactName":"0548538616","phones":"0548538616","invoiceName":"תמך","invoiceAddress":"","fax":"","accessPassword":"1234","recordPassword":"1234","email":"5319sb@gmail.com","organization":"התראות מדיקל","creditFile":"Yemot","username":"0796075824","yemotAPIVersion":6}
                // תגובה שגויה-
                //{"yemotAPIVersion":6,"responseStatus":"EXCEPTION","message":"IllegalStateException(session token is invalid)"}

                //שליחת הודעה קולית
                //https://private.call2all.co.il/ym/api/SendTTS?token=XXXX&phones=XXX:XXX&ttsMessage=%D7%A9%D7%9C%D7%95%D7%9D&ttsRate=X&ttsVoice=XX
            }
            catch (Exception e)
            {
                Console.WriteLine("error message" + e.ToString());

            }

            // Prepare Postal classes to work outside of ASP.NET request
            //var viewsPath = Path.GetFullPath(HostingEnvironment.MapPath(@"~/Views/Emails"));
            //var engines = new ViewEngineCollection();
            //engines.Add(new FileSystemRazorViewEngine(viewsPath));

            //var emailService = new EmailService(engines);

            //// Get comment and send a notification.
            //using (var db = new MailerDbContext())
            //{
            //    var comment = db.Comments.Find(commentId);

            //    var email = new NewCommentEmail
            //    {
            //        To = "yourmail@example.com",
            //        UserName = comment.UserName,
            //        Comment = comment.Text
            //    };

            //    emailService.Send(email);
            //}
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        public static void ConnectYemotMashiach(string URL)
        {
            //private const string URL = "https://sub.domain.com/objects.json";
            //private string urlParameters = "?api_key=123";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                //// Parse the response body.
                //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.Name);
                //}

                Console.WriteLine("secsess!!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
        
    }
}