using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Patient_Model : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string name_with_birthdate { get; set; }
        public DateTime birthday { get; set; }
        public string birthday_string { get; set; }
        public string sex { get; set; }
        public string health_insurance_provider { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public string practice_id { get; set; }
        public bool has_participation_consent { get; set; }
        public DateTime participation_consent_from { get; set; }
        public DateTime participation_consent_to { get; set; }
        public string last_first_op_doctor_name { get; set; }
        public string op_doctor_lanr { get; set; }
        public string last_first_ac_doctor_name { get; set; }
        public string ac_doctor_lanr { get; set; }
        public string op_practice_id { get; set; }
        public string practice { get; set; }
        public string practice_bsnr { get; set; }
        public string op_doctor_id { get; set; }
        public string ac_doctor_id { get; set; }
        public string ac_practice_id { get; set; }
        public string ac_practice { get; set; }
        public string ac_practice_bsnr { get; set; }
        public bool has_rejected_oct { get; set; }
        public string originating_patient_id { get; set; }
        public string originating_practice_name { get; set; }
        public string originating_practice_id { get; set; }
        public string external_id { get; set; }
    }
}
