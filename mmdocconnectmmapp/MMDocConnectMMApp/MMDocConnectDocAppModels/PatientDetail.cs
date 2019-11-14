using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class PatientDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public string health_insurance_provider { get; set; }
        public string participation_consent { get; set; }
        public string cases { get; set; }
        public bool is_privately_insured { get; set; }
        public EyeInformation left_eye { get; set; }
        public EyeInformation right_eye { get; set; }
        public string fee_waived_from { get; set; }
        public string external_id { get; set; }
        
        public PatientDetail()
        {
            left_eye = new EyeInformation();
            right_eye = new EyeInformation();
        }
    }

    public class EyeInformation
    {
        public DateTime? latest_op_date { get; set; }

        public int op_count { get; set; }

        public DateTime? latest_oct_date { get; set; }

        public int oct_count { get; set; }

        public Guid oct_doctor_id { get; set; }

        public string oct_doctor_name { get; set; }
        public string start_treatment_year { get; set; }
    }
}
