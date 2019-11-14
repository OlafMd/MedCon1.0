using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class PatientDetailViewData
    {
        public PatientDetail patient { get; set; }
        public List<ContractModel> ContractList { get; set; }
    }
}
