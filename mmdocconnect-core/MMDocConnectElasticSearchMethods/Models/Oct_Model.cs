using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Oct_Model : IElasticMapper
    {
        public string id { get; set; }

        public DateTime treatment_date { get; set; }

        public DateTime oct_date { get; set; }

        public DateTime treatment_year_date { get; set; }

        public string patient_name { get; set; }

        public DateTime patient_birthdate { get; set; }

        public string diagnose { get; set; }

        public Guid diagnose_id { get; set; }

        public string localization { get; set; }

        public string treatment_doctor_name { get; set; }

        public Guid treatment_doctor_id { get; set; }

        public string treatment_doctor_practice_name { get; set; }

        public Guid treatment_doctor_practice_id { get; set; }

        public string oct_doctor_name { get; set; }

        public Guid oct_doctor_id { get; set; }

        public int treatment_year_octs { get; set; }

        public string status { get; set; }

        public string group_name { get; set; }

        public Guid case_id { get; set; }

        public Guid practice_id { get; set; }

        public Guid patient_id { get; set; }

        public string treatment_doctor_lanr { get; set; }

        public string oct_doctor_lanr { get; set; }

        public string treatment_doctor_practice_bsnr { get; set; }

        public string patient_insurance_number { get; set; }

        public string patient_hip { get; set; }

        public string hip_ik { get; set; }
    }
}
