using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class MedicationApiModel : TransactionalInformation
    {
        public List<MedicationModel> medications { get; set; }
        public MedicationModel medication { get; set; }
    }
}