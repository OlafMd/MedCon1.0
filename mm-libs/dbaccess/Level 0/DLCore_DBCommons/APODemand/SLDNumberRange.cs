using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum ENumberRangeUsageAreaType
    {
        [Description("number-range-usage-area.shoping-cart-number")]
        ShopingCartNumber,
        [Description("number-range-usage-area.customer-order-number")]
        CustomerOrderNumber,
        [Description("number-range-usage-area.customer-interaction-number")]
        CustomerInteractionNumber,
        [Description("number-range-usage-area.procurement-order-number")]
        ProcurementOrderNumber,
        [Description("number-range-usage-area.expected-delivery-number")]
        ExpectedDeliveryNumber,
        [Description("number-range-usage-area.stock-receipt-number")]
        StockReceiptNumber,
        [Description("number-range-usage-area.shipment-number")]
        ShipmentNumber,
        [Description("number-range-usage-area.bill-number")]
        BillNumber,
        [Description("number-range-usage-area.customer-return-number")]
        CustomerReturnNumber,
        [Description("number-range-usage-area.supplier-return-shipment-number")]
        SupplierReturnShipmentNumber,
        [Description("number-range-usage-area.prc-request-proposal-number")]
        PRCRequestProposalNumber,
        [Description("number-range-usage-area.cuo-request-proposal-number")] 
        CUORequestProposalNumberCustomer
    }

    public static partial class ResourceFilePath
    {
        public static String NumberRangeUsageAreaType = "DLCore_DBCommons.APODemand.StaticListDataResource.number-range-usage-area.xml";
    }
}
