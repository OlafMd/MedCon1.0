using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EDefaultContentAdjustmentsReason
    {
        [Description("default-content-adjustment-reasons.broken-expired")]
        BrokenExpired,
        [Description("default-content-adjustment-reasons.theft")]
        Theft,
        [Description("default-content-adjustment-reasons.first-inventory")]
        FirstInventory,
        [Description("default-content-adjustment-reasons.stock-mistake")]
        StockMistake

    }

    public static partial class ResourceFilePath
    {
        public static String DefaultContentAdjustmentsReasons = "DLCore_DBCommons.APODemand.StaticListDataResource.default-content-adjustment-reason.xml";
    }
}
