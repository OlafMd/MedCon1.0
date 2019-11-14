using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class PatientDetailViewData
    {
        public PatientDetail patient { get; set; }
        public List<ContractModel> ContractList { get; set; }

        public PatientDetailViewData()
        {
            this.patient = new PatientDetail();
            this.ContractList = new List<ContractModel>();
        }
    }
}
