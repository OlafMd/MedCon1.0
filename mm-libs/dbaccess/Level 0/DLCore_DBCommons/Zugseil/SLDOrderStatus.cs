using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DLCore_DBCommons.Zugseil
{
    public enum ECustomerOrderStatus
    {
        [Description("customer-order-status.ordered")]
        Ordered,
        [Description("customer-order-status.confirmed")]
        Confirmed,
        [Description("customer-order-status.shipped")]
        Shipped,
        [Description("customer-order-status.billed")]
        Billed,
        [Description("customer-order-status.rejected")]
        Rejected
    }

    public enum EProcurementStatus
    {
        [Description("procurement-status.created")]
        Created,
        [Description("procurement-status.active")]
        Active,
        [Description("procurement-status.rejected")]
        Rejected,
        [Description("procurement-status.confirmed")]
        Confirmed,
        [Description("procurement-status.shipped")]
        Shipped,
        [Description("procurement-status.partialyshipped")]
        PartiallyShipped,
        [Description("procurement-status.ordered")]
        Ordered
    }
    
    public enum EShipmentStatus
    {
        [Description("shipment-statuses.created")]
        Created,
        [Description("shipment-statuses.manually-cleared-for-picking")]
        ManuallyClearedForPicking,
        [Description("shipment-statuses.partialy-ready-for-picking")]
        PartiallyReadyForPicking,
        [Description("shipment-statuses.picking-finished")]
        PickingFinished,
        [Description("shipment-statuses.picking-started")]
        PickingStarted,
        [Description("shipment-statuses.ready-for-picking")]
        ReadyForPicking,
        [Description("shipment-statuses.remind-return-shipment")]
        RemindReturnShipment,
        [Description("shipment-statuses.returned")]
        Returned,
        [Description("shipment-statuses.shipped")]
        Shipped,
        [Description("shipment-statuses.billed")]
        Billed,
        [Description("shipment-statuses.credited")]
        Credited,
        [Description("shipment-statuses.deleted")]
        Deleted,
        [Description("shipment-statuses.flags-are-cleared")]
        FlagsCleared
    }
    public static partial class ResourceFilePath
    {
        public static String CustomerOrderStatus = "DLCore_DBCommons.Zugseil.StaticListDataResource.customer-order-status.xml";
        public static String ProcurementStatus = "DLCore_DBCommons.Zugseil.StaticListDataResource.procurement-order-status.xml";
        public static String ShipmentStatus = "DLCore_DBCommons.Zugseil.StaticListDataResource.shipment-status.xml";
    }
}
