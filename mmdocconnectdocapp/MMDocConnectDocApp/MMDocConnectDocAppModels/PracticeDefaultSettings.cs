using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class PracticeDefaultSettings
    {
        public bool practice_orders_drugs { get; set; }
        public double drugs_delivery_date_offset { get; set; }
        public bool label_only { get; set; }

        public bool quick_order { get; set; }
        public string delivery_date_from { get; set; }

        public string delivery_date_to { get; set; }
    }

    public enum EPracticeParameters
    {
        [Description("mm.docconnect.practice.show-submitted-order-message")]
        ShowSubmittedOrderMessage,
    }
}
