using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangfire.Mailer.Models
{
    public class Medical
    {
        public int MedicalId { get; set; }
        public int PatientId { get; set; }
        public string MedicalName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean Status { get; set; }
        public string CronExpress { get; set; }
        // MedicalId = c.Int(nullable: false, identity: true),
        //            PatientId = c.Int(nullable: false),
        //             MedicalName = c.String(nullable: false),
        //             CreateDate = c.DateTime(nullable: false),
        //             UpdateDate = c.DateTime(nullable: false),
     //   Status = c.Boolean(nullable: false),
      //             CronExpress = c.String(nullable: false)
     }
}