using System;
using System.Collections.Generic;
using BOp.Message;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DLCore_MessageListener.Messages
{

    [DataContract(Name = "CustomerOrderDeadlineChange")]
    public class CustomerOrderDeadlineChange
    {

        public const string MESSAGE_TYPE = "realm.apo-demand.customer-order-deadline-change.update";

        #region Properties

        public Guid CreatedBy_TenantID { get; set; }
        public Guid IntendedFor_TenantID { get; set; }

        [XmlArrayItem(ElementName = "Deadline")]
        public List<CustomerOrderTime> Deadlines { get; set; }

        #endregion

        public string ToPayLoad()
        {
            return SerializationUtils.SerializeObject<CustomerOrderDeadlineChange>(this);
        }

        public static CustomerOrderDeadlineChange FromPayLoad(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<CustomerOrderDeadlineChange>(decodedPayload);
        }

    }

    public class CustomerOrderTime
    {
        public String OldCroneExpression { get; set; }
        public String NewCroneExpression { get; set; }
        public float TimeToDeliveryInMin { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
