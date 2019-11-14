using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class OrdersParameter
    {
        public IEnumerable<Guid> order_ids { get; set; }
    }
}