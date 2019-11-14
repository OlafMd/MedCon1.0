using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class DoctorDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string practice { get; set; }
        public Guid practice_id { get; set; }
        public bool is_bank_inherited { get; set; }
        public string lanr { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string bank_name { get; set; }
        public string bic { get; set; }
        public string iban { get; set; }
        public string account_holder { get; set; }
        public string town { get; set; }
        public string login_email { get; set; }
        public bool account_deactivated { get; set; }
        public bool is_temp { get; set; }
        public string comment { get; set; }
        public string salutation { get; set; }
        public string customer_number { get; set; }
        public bool is_certificated_for_oct { get; set; }
        public string oct_valid_from { get; set; }
    }
}
