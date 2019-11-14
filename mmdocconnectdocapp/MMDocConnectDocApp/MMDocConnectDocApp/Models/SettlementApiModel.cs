using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class SettlementApiModel : TransactionalInformation
    {
        public List<Settlement_Model> settlement { get; set; }
    }

    public class SettlementApiModelMultiEdit : TransactionalInformation
    {
        public settlementMultiResult settlementChanged { get; set; }
    }

}