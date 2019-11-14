using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class PatientModelFront : Patient_Model
    {
        public string participation_consent_status { get; set; }
        public string group_name { get; set; }
    }
}
