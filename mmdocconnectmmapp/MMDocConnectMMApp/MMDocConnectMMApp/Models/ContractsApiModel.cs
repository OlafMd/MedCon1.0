using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ContractsApiModel : TransactionalInformation
    {
        public List<objDoc> Contracts { get; set; }
    }
}