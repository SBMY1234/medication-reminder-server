using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hangfire.Mailer.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PFirstName { get; set; }
        public string PLastName { get; set; }
        public string PPhone { get; set; }
        public string AnotherPhone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string IDNumber { get; set; }

        public string FFirstName { get; set; }
        public string FLastName { get; set; }
        public string FPhone { get; set; }
        public DateTime RegistDate { get; set; }
        public string HMO { get; set; }

        // PatientId = c.Int(nullable: false, identity: true),
        //PFirstName = c.String(nullable: false),
        // PLastName = c.String(nullable: false),
        // PPhone = c.String(nullable: false),
        //AnotherPhone = c.String(nullable: true),
        // Email = c.String(nullable: true),
       // BirthDay = c.DateTime(nullable: true),
        //           IDNumber = c.String(nullable: true),
        //           FFirstName = c.String(nullable: true),
        //           FLastName = c.String(nullable: true),
        //           FPhone = c.String(nullable: true),
        //           RegistDate = c.DateTime(nullable: false),
        //           HMO = c.String(nullable: false),
    }
}