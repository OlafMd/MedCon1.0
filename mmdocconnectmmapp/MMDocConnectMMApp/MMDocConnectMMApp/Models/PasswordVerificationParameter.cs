using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class PasswordVerificationParameter : TransactionalInformation
    {
        public string password { get; set; }
        public string user_login_email { get; set; }
    }
}