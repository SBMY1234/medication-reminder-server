using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangfire.Mailer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string LoginIdPhone { get; set; }
       public string Password     { get; set; }
       public string PFirstName   { get; set; }
       public string PLastName    { get; set; }
       public string Email        { get; set; }
       public DateTime CreateDate   { get; set; }   
    }
}