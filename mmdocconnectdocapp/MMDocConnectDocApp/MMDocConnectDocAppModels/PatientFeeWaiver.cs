using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class PatientFeeWaiver
    {
        public Guid patient_id { get; set; }
        public string issue_date { get; set; }
    }
}
