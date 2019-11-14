using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class Practice
    {
        public string inPassword { get; set; }

        public string bank { get; set; }
        public string bic { get; set; }
        public string address { get; set; }
        public string bsnr { get; set; }
        public string email { get; set; }
        public string iban { get; set; }
        public string fax { get; set; }
        public string id { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string town { get; set; }
        public string account_holder { get; set; }
        public int default_shipping_date_offset { get; set; }
        public string login_email { get; set; }
        public string password { get; set; }
        public string contact_email { get; set; }
        public string contact_person_name { get; set; }
        public string contact_telephone { get; set; }
        public string No { get; set; }
        public int ZIP { get; set; }
        public bool IsSurgeryPractice { get; set; }
        public bool IsOrderDrugs { get; set; }
        public bool IsOnlyLabelRequired { get; set; }
        public bool isWaiveServiceFee { get; set; }
        public bool ShouldDownloadReportUponSubmission { get; set; }
        public bool PressEnterToSearch { get; set; }
        public bool PracticeHasOctDevice { get; set; }

        public String DefaultPharmacy { get; set; }
        public bool IsQuickOrderActive { get; set; }

        public string DeliveryDateFrom { get; set; }
        public string DeliveryDateTo { get; set; }

        public bool UseGracePeriod { get; set; }
    }

    public class PracticeAddress
    {
        public string street { get; set; }
        
        public string city { get; set; }

        public string number { get; set; }

        public string zip { get; set; }

        public string name { get; set; }

        public string default_pharmacy { get; set; }

        public string delivery_date_from { get; set; }

        public string delivery_date_to { get; set; }
    }
}
