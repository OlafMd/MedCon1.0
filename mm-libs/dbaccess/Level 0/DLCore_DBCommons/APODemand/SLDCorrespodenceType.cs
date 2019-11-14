using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum ECorrespondenceType
    {
        [Description("personinfo-correspondence-type.letter")]
        Letter,
        [Description("personinfo-correspondence-type.delivery-paper")]
        DeliveryPaper,
        [Description("personinfo-correspondence-type.dunning")]
        Dunning,
        [Description("personinfo-correspondence-type.bill")]
        Bill
    }

    public static partial class ResourceFilePath
    {
        public static String CorrespondenceTypes = "DLCore_DBCommons.APODemand.StaticListDataResource.correspondence-type.xml";
    }
}
