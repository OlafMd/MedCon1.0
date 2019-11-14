using MMDocConnectDBMethods.Doctor.Complex.Retrieval;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class PracticeApiModel : TransactionalInformation
    {
        public DO_GPDD_1700 practice { get; set; }

        public bool isPracticeLoggedIn { get; set; }
    }
}