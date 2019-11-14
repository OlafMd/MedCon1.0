using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Settlement_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public string group_name { get; set; }
        public DateTime surgery_date { get; set; }
        public string surgery_date_string { get; set; }
        public string surgery_date_string_month { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patient_full_name { get; set; }
        public string birthday { get; set; }
        public string case_type { get; set; }
        public string diagnose { get; set; }
        public string drug { get; set; }
        public string localization { get; set; }
        public string doctor { get; set; }
        public string acpractice { get; set; }
        public string status { get; set; }
        public bool is_edit_button_visible { get; set; }
        public bool is_submit_button_visible { get; set; }
        public bool is_cancel_button_visible { get; set; }
        public string practice_id { get; set; }
        public string if_aftercare_treatment_date { get; set; }
        public string previous_status { get; set; }
        public string patient_id { get; set; }
        public string treatment_doctor_id { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }
        public string hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string lanr { get; set; }
        public string bsnr { get; set; }
        public bool is_aftercare_performed { get; set; }
        public bool is_report_downloaded { get; set; }
        public string ac_status { get; set; }
        public string hip_ik_number { get; set; }
        public DateTime status_date { get; set; }
    }

    public class Settlement_ModelMultiEdit : IElasticMapper
    {
        public string id { get; set; }
    }
}
