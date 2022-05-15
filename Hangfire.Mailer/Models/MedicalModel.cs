using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangfire.Mailer.Models
{
    public class MedicalModel
    {
        public int MedicalId { get; set; }
        public int PatientId { get; set; }
        public string MedicalName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Boolean Status { get; set; }
        public string CronExpress { get; set; }
     
     }
}