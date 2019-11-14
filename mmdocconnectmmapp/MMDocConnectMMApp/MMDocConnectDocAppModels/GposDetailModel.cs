using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class GposDetailModel
    {
        public Guid gpos_id { get; set; }
        public string gpos_number { get; set; }
        public string gpos_type { get; set; }
        public string gpos_name { get; set; }
        public string from_injection { get; set; }
        public double fee_value { get; set; }
        public string management_fee_value { get; set; }
        public bool waive_with_order { get; set; }
        public string drug_names { get; set; }
        public string diagnose_names { get; set; }
        public List<CoveredItemModel> drugs { get; set; }
        public List<CoveredItemModel> diagnoses { get; set; }
    }
}