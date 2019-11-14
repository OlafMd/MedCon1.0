using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_APOProcurement_Proposals.Complex.Models
{
    public class HistoryModel
    {
        public bool IsEvent_ProposalRequest_Sent { get; set; }
        public bool IsEvent_ProposalRequest_Revoked { get; set; }
        public bool IsEvent_ProposalResponse_Declined  { get; set; }
        public bool IsEvent_ProposalResponse_Accepted { get; set; }
        public string Comment { get; set; }
    }
}
