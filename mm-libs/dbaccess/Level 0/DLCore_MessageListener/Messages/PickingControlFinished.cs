using System;
using System.Runtime.Serialization;
using BOp.Message;

namespace Realm.APODemand
{
    [DataContract(Name = "PickingControlFinished")]
    public class PickingControlFinished
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.picking-control-finished.request";

        #region Properties

        public Guid CreatedBy_TenantID { get; set; }
        public Guid IntendedFor_TenantID { get; set; }

        public Guid ProcurementOrderITL { get; set; }
        public bool IsProcurementPartialyShipped { get; set; }

        public String ShoppingCart_OfficeITL { get; set; }
        public bool ShoppingCart_IsPartialyShipped { get; set; }

        #endregion

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<PickingControlFinished>(this);
        }

        public static PickingControlFinished FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<PickingControlFinished>(decodedPayload);
        }
    }
}
