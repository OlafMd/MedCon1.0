using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ValidationParameter : TransactionalInformation
    {
        public Guid ID { get; set; }
        public string Type { get; set; }
        public string ContentToValidate { get; set; }
    }
}