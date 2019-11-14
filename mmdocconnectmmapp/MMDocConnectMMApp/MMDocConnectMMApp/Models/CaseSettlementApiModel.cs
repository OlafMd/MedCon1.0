using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class CaseSettlementApiModel : TransactionalInformation
    {
        public Case_Settlement_Model CaseSettlement { get; set; }
    }
}