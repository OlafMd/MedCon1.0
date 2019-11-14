using MMDocConnectDocAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class PasswordVerificationParameter : TransactionalInformation
    {
        public AutocompleteModel doctor { get; set; }
        public string password { get; set; }
    }
}