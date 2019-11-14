using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class Account
    {
        
        public String id { get; set; }
        
        public String practice_id { get; set; }
        
        public String address { get; set; }
        
        public String practice { get; set; }
        
        public String bank_name { get; set; }
        
        public String bic { get; set; }
        
        public String phone { get; set; }
        
        public String iban { get; set; }
        
        public String lanr { get; set; }
        
        public String first_name { get; set; }
        
        public String last_name { get; set; }
        
        public String title { get; set; }
        
        public String email { get; set; }
        
        public bool is_bank_inherited { get; set; }
        
        public String login_email { get; set; }
        
        public String account_holder { get; set; }
        
        public String password { get; set; }
        
        public String salutation { get; set; }
        public string inPassword { get; set; }
    }
}
