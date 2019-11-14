using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class PracticeModel : TransactionalInformation
    {
        public Guid PracticeID { get; set; }
        public string PracticeName { get; set; }
        public string BSNR { get; set; }
        public string Street { get; set; }
        public string No { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string MainEmail { get; set; }
        public string MainPhone { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bic { get; set; }
        public string IBAN { get; set; }
        public string Bank { get; set; }
        public string PracticeAccount { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }

        public bool IsSurgeryPractice { get; set; }
        public bool IsOrderDrugs { get; set; }
        public string DefaultShippingDateOffset { get; set; }
        public bool IsOnlyLabelRequired { get; set; }
        public bool isWaiveServiceFee { get; set; }

    }
}