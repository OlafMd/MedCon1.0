using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class Doctor_Model
    {
        public string title { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string lanr { get; set; }
        public string account_holder { get; set; }
        public string bic { get; set; }
        public string iban { get; set; }
        public string bank_name { get; set; }
        public string login_email { get; set; }
        public List<Practice_Model_for_import> practice_list { get; set; }
    }

    public class Practice_Model_for_import
    {
        public string bsnr { get; set; }
        public string name { get; set; }
    }
}
