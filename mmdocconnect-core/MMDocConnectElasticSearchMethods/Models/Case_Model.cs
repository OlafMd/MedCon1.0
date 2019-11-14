using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Case_Model : IElasticMapper
    {
        public string id { get; set; }
        public string order_id { get; set; }
        public DateTime treatment_date { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string diagnose { get; set; }
        public string drug { get; set; }
        public string localization { get; set; }
        public string treatment_doctor_name { get; set; }
        public string aftercare_name { get; set; }
        public string status_drug_order { get; set; }
        public string status_treatment { get; set; }
        public string group_name { get; set; }
        public bool is_aftercare_doctor { get; set; }
        public string aftercare_doctors_practice_name { get; set; }
        public string practice_id { get; set; }
        public DateTime order_modification_timestamp { get; set; }
        public string order_modification_timestamp_string { get; set; }
        public DateTime delivery_time_from { get; set; }
        public DateTime delivery_time_to { get; set; }
        public string delivery_time_string { get; set; }
        public bool is_orders_drug { get; set; }
        public string previous_status_drug_order { get; set; }
        public bool is_submit_button_visible { get; set; }
        public bool is_submit_order_button_visible { get; set; }
        public bool is_edit_button_visible { get; set; }
        public string treatment_doctor_lanr { get; set; }
        public string aftercare_doctor_lanr { get; set; }
        public string patient_hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string patient_id { get; set; }
        public string aftercare_practice_bsnr { get; set; }
        public string treatment_doctor_id { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }
        public string aftercare_doctors_practice_id { get; set; }
    }
}
