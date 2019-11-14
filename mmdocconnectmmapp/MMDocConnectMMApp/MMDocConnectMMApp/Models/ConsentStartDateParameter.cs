using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ConsentStartDateParameter
    {
        public string doctor_id { get; set; }
        public Guid contract_id { get; set; }
    }
}