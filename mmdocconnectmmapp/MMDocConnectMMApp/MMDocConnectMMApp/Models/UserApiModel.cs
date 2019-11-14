using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class UserApiModel : TransactionalInformation
    {
        public string name { get; set; }
        public bool isMaster { get; set; }
        public string loginEmail { get; set; }
        public DateTime startTime { get; set; }

    }
}