using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class LoginApiModel : TransactionalInformation
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}