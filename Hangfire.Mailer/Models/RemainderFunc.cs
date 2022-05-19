using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Hangfire.Mailer.Models
{
    public static class RemainderFunc
    {
        public static void NotifyNewRemainder(int personId, string cronExpress)
        {
            var currentCultureName = Thread.CurrentThread.CurrentCulture.Name;
            if (currentCultureName != "he-IL")
            {
                throw new InvalidOperationException(String.Format("Current culture is {0}", currentCultureName));
            }
            // Get user tel and list medical.
            using (var db = new MailerDbContext())
            {
                // var tel = db.Patient.
                var P1 = db.Patient.Find(personId);
                var Phon = P1.FPhone;
                var FName = P1.FFirstName;
                var LName = P1.FLastName;

               // var med = db.Medical.Where(a => a.PatientId.Equals(personId) && a.Status == true).Select(a => a.MedicalName).ToList(); // for now sending
                var med = db.Medical.Where(a => a.PatientId.Equals(personId) && a.CronExpress.Equals(cronExpress) && a.Status == true).Select(a => a.MedicalName).ToList();
                if (med != null)
                {
                    var madicallist = string.Join(" ", med.ToArray());
                    string Msg = "shalom " + FName + " " + LName + " " + " zohi tizkoret mimaarechet truephone lelekichat trufot " + madicallist + " rak brioot";
                    string token = ConfigurationManager.AppSettings["tokenYemotMashiach"];
                    ConnectYemotMashiachAsync("GetSession?token=", token, Phon.ToString(), Msg);
                }
                //TODO create massege & send by yemot mashiach. 
            }

        }
        public static async Task ConnectYemotMashiachAsync(string method, string token, string phone, string msg)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://private.call2all.co.il/ym/api/");

                var response = await client.GetAsync(method + token);
                string responseString = String.Empty;

                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(responseString).SelectToken("responseStatus").ToString();
                    if (result.Contains("OK"))
                    {
                        SendMessageAsync(token, phone, msg);
                        Console.WriteLine("secsess!! GetSession" + result);
                    }
                    else
                    {
                        CreateNewTokenAsync("Login?username=0796075824&password=0548538616&", phone, msg);
                    }

                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private static async void CreateNewTokenAsync(string url, string phone, string msg)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://private.call2all.co.il/ym/api/");


                var response = await client.GetAsync(url);
                string responseString = String.Empty;

                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(responseString).SelectToken("responseStatus").ToString();
                    if (result.Contains("OK"))
                    {
                        var token = JObject.Parse(responseString).SelectToken("token").ToString();
                        Console.WriteLine("secsess!! create token " + result);

                        //update token at app config 
                        Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                        configuration.AppSettings.Settings["tokenYemotMashiach"].Value = token;
                        configuration.Save();
                        ConfigurationManager.RefreshSection("appSettings");

                        SendMessageAsync(token, phone, msg);
                    }
                    else
                    {
                        //  CreateNewTokenAsync("Login?username=0796075824&password=0548538616&", phone, msg);

                        Console.WriteLine("faild!! Login" + result);
                    }


                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }


        }
        public static async void SendMessageAsync(string token, string phone, string msg)
        {
            var URL = "SendTTS?token=" + token + "&phones=" + phone + "&ttsMessage=" + msg + "&ttsRate=-6";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://private.call2all.co.il/ym/api/");

                var response = await client.GetAsync(URL);
                string responseString = String.Empty;

                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(responseString).SelectToken("responseStatus").ToString();
                    if (result.Contains("OK")) //? SendMessage() : CreateNewTokenAsync("Login?username=0796075824&password=0548538616&"))

                        Console.WriteLine("secsess!! send message" + result);
                    else
                    {
                        Console.WriteLine("fail send message " + result);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

    }
}