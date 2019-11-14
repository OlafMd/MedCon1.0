using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class InitalPatientDataModel
    {
        public List<HIPModel> HIPList { get; set; }
        public List<ContractModel> ContractList { get; set; }
    }

    public class HIPModel
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ContractModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public double participation_consent_valid_days { get; set; }
    }
}
