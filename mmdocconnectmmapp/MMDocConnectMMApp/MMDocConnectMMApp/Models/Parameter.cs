using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class Parameter : TransactionalInformation
    {
        public Guid id { get; set; }
        public string text { get; set; }
        public bool bool_value { get; set; }
        public Guid secondary_id { get; set; }
        public string action_type { get; set; }
    }
}