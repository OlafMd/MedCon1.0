using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class ReceiptApiModel : TransactionalInformation
    {
        public List<Receipt_Model> receipts { get; set; }
    }
}