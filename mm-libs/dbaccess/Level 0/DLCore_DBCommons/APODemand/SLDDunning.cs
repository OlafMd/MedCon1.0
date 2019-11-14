using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EDunningType
    {
        [Description("dunning-type.paymentremainder")]
        PaymentRemainder,
        [Description("dunning-type.dunning")]
        Dunning,
        [Description("dunning-type.lawsuit")]
        LawSuit
    }

    public static partial class ResourceFilePath
    {
        public static String DunningType = "DLCore_DBCommons.APODemand.StaticListDataResource.dunning-type.xml";
    }
}
