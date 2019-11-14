using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BOp.Message;

namespace DLCore_MessageListener.Messages
{
    [DataContract(Name = "CustomerOrderTrigger")]
    public class CustomerOrderTrigger
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.customer-order-trigger.request";

        #region Properties

        public List<Guid> CustomerTenantIdList { get; set; }

        #endregion

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<CustomerOrderTrigger>(this);
        }

        public static CustomerOrderTrigger FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<CustomerOrderTrigger>(decodedPayload);
        }
    }

}
