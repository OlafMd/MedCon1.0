
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class ResponseCasesApiModel: TransactionalInformation
    {
         public  PositioveResponseCaseModel PositiveModel {get; set;}
         public NegativeResponseCaseModel NegativeModel { get; set; }
        

         public int NonEligibleStatuses { get; set; }
         public int TotalCases{ get; set; }
         public bool isPositiveResponce { get; set; }

   

        public ResponseCasesApiModel()
        {
            this.NegativeModel = new NegativeResponseCaseModel();
            this.PositiveModel = new PositioveResponseCaseModel();
            this.NonEligibleStatuses = 0;
            this.TotalCases = 0;
        }
    }
}