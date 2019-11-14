using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class PatientDetailViewModel : IElasticMapper
    {
        public string id { get; set; }
        public string practice_id { get; set; }
        public string patient_id { get; set; }
        public DateTime date { get; set; }
        public string date_string { get; set; }
        public string detail_type { get; set; }
        public string diagnose_or_medication { get; set; }
        public string localisation { get; set; }
        public string doctor { get; set; }
        public string status { get; set; }
        public string group_name { get; set; }
        public string drug { get; set; }
        public string order_status { get; set; }
        public string previous_order_status { get; set; }
        public string order_id { get; set; }
        public string case_id { get; set; }
        public bool if_settlement_is_report_downloaded { get; set; }

       /**********************************************************/
        public string treatment_doctor_id { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }

        public string pharmacy_id { get; set; }
        public string pharmacy_name { get; set; }
        public string hip_ik { get; set; }
        public  PatientDetailViewModel()
        {
            this.localisation = "-";
            this.doctor = "-";
        }

    }
}
