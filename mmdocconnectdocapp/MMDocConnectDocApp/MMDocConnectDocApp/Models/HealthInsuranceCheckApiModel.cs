using MMDocConnectDocAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class HealthInsuranceCheckApiModel : TransactionalInformation
    {
        public HealthInsuranceCheck  healthInsuranceCheck {get;set;}
    }
}