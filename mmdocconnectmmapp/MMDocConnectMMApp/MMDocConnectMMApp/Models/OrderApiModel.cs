using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class OrderApiModel : TransactionalInformation
    {
        public List<Order_Model_Extended> OrderData { get; set; }
    }
}