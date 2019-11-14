using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class UserApiModel : TransactionalInformation
    {
        public string name { get; set; }
        public bool isOpRole { get; set; }
        public bool isDoctor { get; set; }
        public DateTime startTime { get; set; }
        public string loginEmail { get; set; }
        public bool canAddPreexaminations { get; set; }
        public Guid id { get; set; }
    }
}