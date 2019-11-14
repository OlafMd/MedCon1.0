using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{

    public class Submitted_Case_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public DateTime treatment_date { get; set; }
        public DateTime if_aftercare_treatment_date { get; set; }
        public string treatment_date_string { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string type { get; set; }
        public string diagnose { get; set; }
        public string diagnose_id { get; set; }
        public string drug { get; set; }
        public string drug_id { get; set; }
        public string localization { get; set; }
        public string status { get; set; }
        public string management_pauschale { get; set; }
        public string group_name { get; set; }
        public DateTime status_date { get; set; }
        public string status_date_string { get; set; }
        public string doctor_name { get; set; }
        public string practice_id { get; set; }
        public string practice_name { get; set; }
        public string hip_name { get; set; }
        public string doctor_lanr { get; set; }
        public string practice_bsnr { get; set; }
        public string patient_insurance_number { get; set; }
        public string doctor_id { get; set; }
        public string patient_id { get; set; }
    }
}