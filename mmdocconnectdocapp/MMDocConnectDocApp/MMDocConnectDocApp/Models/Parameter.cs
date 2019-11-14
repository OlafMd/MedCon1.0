using MMDocConnectDocAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class Parameter
    {
        public Guid id { get; set; }
        public string type { get; set; }
        public bool flag { get; set; }
        public string date_string { get; set; }
        public Guid secondary_id { get; set; }
        public Guid tertiary_id { get; set; }
        public Guid drug_id { get; set; }
        public Guid diagnose_id { get; set; }
        public Guid[] multi_ids { get; set; }
        public Guid[] deselected_ids { get; set; }
        public bool secondary_flag { get; set; }
        public FilterObject filter_by { get; set; }
        public string date { get; set; }
        public Guid authorizing_doctor_id { get; set; }
        public Guid case_id { get; set; }

    }
}