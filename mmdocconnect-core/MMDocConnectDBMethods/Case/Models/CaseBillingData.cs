using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Case.Models
{
    public class CaseBillingData
    {        
        public Guid case_id { get; set; }
        public String case_number { get; set; }
        public Guid bill_position_id { get; set; }
        public Guid gpos_id { get; set; }
        public String fs_status_key { get; set; }
        public int fs_status_code { get; set; }
        public String bill_position_number { get; set; }
        public String gpos_code { get; set; }
        public double gpos_price { get; set; }
        public String gpos_type { get; set; }
        public Guid hec_bill_position_id { get; set; }
        public Guid fs_status_id { get; set; }
    }
}
