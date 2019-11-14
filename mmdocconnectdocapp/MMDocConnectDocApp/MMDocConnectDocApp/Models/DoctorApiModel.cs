using MMDocConnectDBMethods.Doctor.Complex.Retrieval;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class DoctorApiModel : TransactionalInformation
    {
        public DO_GPDD_1137 doctor { get; set; }

        public bool isPracticeLoggedIn { get; set; }
    }
}