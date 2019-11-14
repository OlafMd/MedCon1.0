using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_APOProcurement_Proposals.Complex.Models
{
    public class CustomerHistoryModel
    {
        public bool IsEvent_ProposalRequest_Received {get; set;}
        public bool IsEvent_ByCustomer_ProposalResponse_Declined {get; set;}
        public bool IsEvent_ProposalResponse_Sent { get; set; }
        public string Comment {get; set;}
          
    }
}
