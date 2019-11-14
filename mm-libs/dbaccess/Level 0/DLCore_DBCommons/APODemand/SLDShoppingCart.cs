using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EShoppingCartStatus
    {
        [Description("shopping-cart-status.active")]
        Active,
        [Description("shopping-cart-status.canceled")]
        Canceled,
        [Description("shopping-cart-status.abandoned")]
        Abandoned,
        [Description("shopping-cart-status.approved")]
        Approved,
        [Description("shopping-cart-status.ordered")]
        Ordered,
        [Description("shopping-cart-status.waiting-for-approval")]
        WaitingForApproval,
        [Description("shopping-cart-status.shipped")]
        Shipped,
        [Description("shopping-cart-status.partialyshipped")]
        PartiallyShipped
    }
}
