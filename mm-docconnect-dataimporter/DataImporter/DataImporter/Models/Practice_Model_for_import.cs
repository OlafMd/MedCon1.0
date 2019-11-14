using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class Practice_Model_from_xlsx
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
        public string AccountHolder { get; set; }
        public string Bic { get; set; }
        public string IBAN { get; set; }
        public string Bank { get; set; }
        public string PracticeAccount { get; set; }
        public string LoginEmail { get; set; }
        public string inPassword { get; set; }

        public bool IsSurgeryPractice { get; set; }
        public bool IsOrderDrugs { get; set; }
        public string DefaultShippingDateOffset { get; set; }
        public bool IsOnlyLabelRequired { get; set; }
        public bool isWaiveServiceFee { get; set; }
        public bool isValid { get; set; }
        public string ValidationErrors { get; set; }
    }
}
