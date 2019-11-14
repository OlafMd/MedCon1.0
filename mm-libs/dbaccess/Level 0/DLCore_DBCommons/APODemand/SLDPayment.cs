using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EPaymentType
    {
        [Description("payment-type.installments")]
        Installments
    }

    public static partial class ResourceFilePath
    {
        public static String PaymentTypes = "DLCore_DBCommons.APODemand.StaticListDataResource.payment-type.xml";
    }
}
