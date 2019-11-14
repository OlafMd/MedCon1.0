using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EBillStatus
    {
        [Description("bill-status.created")]
        Created,
        [Description("bill-status.closed")]
        Closed,
        [Description("bill-status.canceled")]
        Canceled
    }

    public static partial class ResourceFilePath
    {
        public static String BillStatus = "DLCore_DBCommons.APODemand.StaticListDataResource.bill-status.xml";
    }
}
