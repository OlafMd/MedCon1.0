using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DLCore_MessageListener.Messages.Zugseil
{
    [DataContract(Name = "UpdateProcurementOrderStatus")]
    public class UpdateProcurementOrderStatus
    {
        public const string MESSAGE_TYPE = "realm.zugseil.procurement-order-status-update.request";

        #region properties
        public string Status { get; set; }

        public Guid ProcurementOrderHeaderID { get; set; }

        public string Comment { get; set; }
        #endregion
    }
}
