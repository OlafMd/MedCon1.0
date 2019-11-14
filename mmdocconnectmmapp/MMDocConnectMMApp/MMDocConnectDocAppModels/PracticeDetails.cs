using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMApp.Models
{
    public class PracticeDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public string bsnr { get; set; }
        public string address { get; set; }
        public string town { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string bank { get; set; }
        public string bic { get; set; }
        public string iban { get; set; }
        public string account_holder { get; set; }
        public int default_shipping_date_offset { get; set; }
        public bool is_only_label_required { get; set; }
        public bool is_order_drugs { get; set; }
        public bool is_surgery_practice { get; set; }
        public bool is_waive_service_fee { get; set; }
        public string login_email { get; set; }
        public contact_person contact { get; set; }
        public bool account_deactivated { get; set; }
        public bool practice_has_doctors { get; set; }
        public long doctor_count { get; set; }
        public bool shouldDownloadReportUponSubmission { get; set; }

        public bool pressEnterToSearch { get; set; }

        public string defaultPharmacy { get; set; }
        public bool isQuickOrderActive { get; set; }
        public string deliveryDateFrom { get; set; }
        public string deliveryDateTo { get; set; }
        public bool useGracePeriod { get; set; }
    }

    public class contact_person
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
