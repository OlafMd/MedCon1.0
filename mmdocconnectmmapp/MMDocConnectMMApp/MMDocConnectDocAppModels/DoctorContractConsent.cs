using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class DoctorContractConsent
    {
        public Guid assignmentID { get; set; }
        public Guid doctorID { get; set; }
        public string consentStartDate { get; set; }
        public string consentEndDate { get; set; }
        public string contractName { get; set; }
        public ContractDetails Contract { get; set; }

        public DoctorContractConsent() 
        {
            this.Contract = new ContractDetails();
        }
    }

    public class ContractDetails 
    {
        public string ContractName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidThrough { get; set; }
        public Guid contractID { get; set; }
    }

    public class ContractOverlapsValidationResponse
    {
        public string consentContractName { get; set; }
        public string consentValidFrom { get; set; }
        public string consentValidThrough { get; set; }
    }
}
