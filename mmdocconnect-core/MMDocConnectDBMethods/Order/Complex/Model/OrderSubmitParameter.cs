using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Order.Complex.Model
{
    public class OrderSubmitParameter
    {
        public IEnumerable<Guid> order_ids { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public string number { get; set; }

        public string zip { get; set; }

        public string receiver { get; set; }

        public string comment { get; set; }

        public Guid doctor_id { get; set; }

        public string delivery_date { get; set; }

        public string delivery_date_from { get; set; }

        public string delivery_date_to { get; set; }

        public Guid default_pharmacy { get; set; }

        public string pharmacy_name { get; set; }

        public string pharmacy_street { get; set; }

        public string pharmacy_street_number { get; set; }

        public string pharmacy_zip_code { get; set; }

        public string pharmacy_town { get; set; }
    }
}
