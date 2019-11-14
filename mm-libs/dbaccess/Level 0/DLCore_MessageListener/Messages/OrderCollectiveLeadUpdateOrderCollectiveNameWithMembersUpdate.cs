using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DLCore_MessageListener.Messages
{
    [DataContract(Name = "OrderCollectiveLeadUpdateOrderCollectiveNameWithMembersUpdate")]
    public class OrderCollectiveLeadUpdateOrderCollectiveNameWithMembersUpdate
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.order-collective-lead.update-order-collective-name-with-members.update";

        #region Properties
        public Guid OrderCollectiveId { get; set; }
        public string OrderCollectiveNewName { get; set; }
        #endregion
    }
}
