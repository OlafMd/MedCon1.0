using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum ESupplierTypes
    {
        [Description("supplier-type.direct")]
        Direct,
        [Description("supplier-type.normal")]
        Normal
    }

    public enum ESuppliers
    {
        [Description("abda-supplier")]
        ABDA
    }

    public static partial class ResourceFilePath
    {
        public static String SupplierTypes = "DLCore_DBCommons.APODemand.StaticListDataResource.supplier-type.xml";
    }
}
