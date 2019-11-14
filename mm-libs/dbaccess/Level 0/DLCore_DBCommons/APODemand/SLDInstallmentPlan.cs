using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EInstallmentPlanStatus
    {
        [Description("installment-plan-status.created")]
        Created,
        [Description("installment-plan-status.payed-in-total")]
        PayedInTotal,
        [Description("installment-plan-status.partially-payed")]
        PartiallyPayed,
        [Description("installment-plan-status.terminated")]
        Terminated
    }

    public static partial class ResourceFilePath
    {
        public static String InstallmentPlanStatus = "DLCore_DBCommons.APODemand.StaticListDataResource.installment-plan-status.xml";
    }
}
