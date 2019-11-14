using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class ParticipationConsent
    {
        public Guid patient_id { get; set; }
        public Guid participation_id { get; set; }
        public Guid contract_id { get; set; }
        public string issue_date { get; set; }
        public int participation_consent_valid_days { get; set; }
        public DateTime contract_ValidTo { get; set; }
    }
}
