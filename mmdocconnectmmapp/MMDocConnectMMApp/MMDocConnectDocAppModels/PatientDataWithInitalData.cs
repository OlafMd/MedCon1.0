using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class PatientDataWithInitalData : InitalPatientDataModel
    {
        public PatientData PatientData { get; set; }
    }

    public class PatientData
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string birthday { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public string health_insurance_provider { get; set; }
        public string contract_id { get; set; }
        public string participation_consent_date { get; set; }
        public bool hasParticipationConsent { get; set; }
        public string sex { get; set; }
    }
}
