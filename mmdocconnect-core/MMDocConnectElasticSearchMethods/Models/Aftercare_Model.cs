using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{

    public class Aftercare_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public DateTime treatment_date { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string diagnose { get; set; }
        public string localization { get; set; }
        public string treatment_doctor_name { get; set; }
        public string treatment_doctor_practice_name { get; set; }
        public string treatment_doctors_practice_id { get; set; }
        public string aftercare_doctor_name { get; set; }
        public string status { get; set; }
        public string group_name { get; set; }
        public string practice_id { get; set; }
        public bool is_submit_visible { get; set; }
        public string aftercare_doctor_account_id { get; set; }
        public string patient_id { get; set; }
        public string hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string op_lanr { get; set; }
        public string ac_lanr { get; set; }
        public string bsnr { get; set; }
        public string aftercare_date_string { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string treatment_doctor_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }
        public string hip_ik_number { get; set; }
        public string max_date_for_submission { get; set; }
    }
}
