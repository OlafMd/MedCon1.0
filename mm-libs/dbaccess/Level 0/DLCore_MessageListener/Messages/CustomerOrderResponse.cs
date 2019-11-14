using System;
using System.Runtime.Serialization;
using BOp.Message;

namespace DLCore_MessageListener.Messages
{
    [DataContract(Name = "CustomerOrderResponse")]
    public class CustomerOrderResponse
    {
               public const string MESSAGE_TYPE = "realm.apo-demand.customer-order-response.update";

        #region Properties

        public Guid CreatedBy_TenantID { get; set; }
        public Guid IntendedFor_TenantID { get; set; }

        public Guid ProcurementOrderITL { get; set; }
        public String ResponseComment { get; set; }
        public bool IsAccepted { get; set; }

        #endregion

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<CustomerOrderResponse>(this);
        }

        public static CustomerOrderResponse FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<CustomerOrderResponse>(decodedPayload);
        }
    }
}
