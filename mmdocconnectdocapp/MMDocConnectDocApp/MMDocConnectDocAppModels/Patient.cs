using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class Patient : IElasticMapper
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bithday { get; set; }
        public string sex { get; set; }
        public HipModel health_insurance_provider { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public string issue_date { get; set; }
        public string participation_id { get; set; }
        public contract contract { get; set; }
        public bool is_privately_insured { get; set; }
        public bool hip_changed { get; set; }
        public string external_id { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1} ({2})", last_name, first_name, bithday);
        }

    }

    public class contract
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public double participation_consent_valid_days { get; set; }
    }
}
