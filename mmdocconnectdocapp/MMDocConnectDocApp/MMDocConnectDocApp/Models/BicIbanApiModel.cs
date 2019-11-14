using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class BicIbanApiModel : TransactionalInformation
    {
        public List<Bic_Iban_Codes> BicIban { get; set; }
    }
}