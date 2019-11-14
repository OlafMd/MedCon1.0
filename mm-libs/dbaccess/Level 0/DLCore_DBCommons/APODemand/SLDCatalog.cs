using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    [Serializable]
    public enum EPrivateCatalogType
    {
        [Description("houselist")]
        Houselist,
        [Description("special-requests")]
        SpecialRequests,
        [Description("treatment-list")]
        Treatment,
    }

    public enum EPublicCatalogs
    {
        [Description("abda-catalog")]
        ABDA
    }

    public enum EProductGroup
    {
        [Description("catalog-houselist.")]
        HauseList,
        [Description("catalog-abda.")]
        ABDA,
        [Description("catalog-special-requests")]
        SpecialRequests,
        [Description("catalog-treatment.")]
        Treatment,
        [Description("custom-articles")]
        CustomArticles
    }
}
