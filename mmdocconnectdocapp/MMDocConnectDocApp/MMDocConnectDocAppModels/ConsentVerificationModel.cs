using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class ConsentVerificationModel
    {
        public Guid ContractID { get; set; }
        public DateTime ContractCreationTimestamp { get; set; }
        public Guid InsuranceToBrokerContractID { get; set; }
    }
}
