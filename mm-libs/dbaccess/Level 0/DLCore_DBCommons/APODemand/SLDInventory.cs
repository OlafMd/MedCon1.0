using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EInvetoryProcessStatus
    {
        [Description("invetory-process-status.created")]
        Created,
        [Description("invetory-process-status.started")]
        Started,
        [Description("invetory-process-status.completed")]
        Completed,
        [Description("invetory-process-status.list-printed")]
        ListPrinted
    }

    public static partial class ResourceFilePath
    {
        public static String InvetoryProcessStatus = "DLCore_DBCommons.APODemand.StaticListDataResource.invetory-process-status.xml";
    }
}
