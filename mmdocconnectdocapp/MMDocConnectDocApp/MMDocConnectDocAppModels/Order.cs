using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class Order
    {
        public Guid id { get; set; }

        public string patient_name { get; set; }

        public string treatment_date { get; set; }

        public Guid drug_id { get; set; }

        public Guid case_id { get; set; }

        public bool fee_waived { get; set; }

        public bool label_only { get; set; }

        public bool send_invoice_to_practice { get; set; }

        public string comment { get; set; }

        public bool is_only_order { get; set; }
    }
}
