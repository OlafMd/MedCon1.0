using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class PatientDetailsApiModel : TransactionalInformation
    {
        public PatientDetail patient { get; set; }
        public List<ContractModel> contract_list { get; set; }

        public List<PatientDetailViewModelExtended> patient_details_list { get; set; }
    }
}