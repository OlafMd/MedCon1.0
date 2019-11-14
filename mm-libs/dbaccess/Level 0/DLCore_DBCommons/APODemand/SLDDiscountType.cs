using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EDiscountType
    {
        [Description("discount-type.main-discount")]
        MainDiscount,
        [Description("discount-type.cash-discount")]
        CashDiscount,
        [Description("discount-type.discount-2")]
        Discount2,
        [Description("discount-type.discount-3")]
        Discount3,
        [Description("discount-type.natural-discount")]
        NaturalDiscount
    }

    public static partial class ResourceFilePath
    {
        public static String DiscountTypes = "DLCore_DBCommons.APODemand.StaticListDataResource.discount-type.xml";
    }
}
