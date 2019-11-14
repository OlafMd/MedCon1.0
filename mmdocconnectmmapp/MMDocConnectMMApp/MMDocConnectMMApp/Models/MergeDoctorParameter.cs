using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class MergeDoctorParameter 
    {
        public Guid doctor_id { get; set; }
        public Guid temporary_doctor_id { get; set; }
    }
}