using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EDefaultReturnPolicy
    {
        [Description("default-return-policies-area.missing")]
        Missing,

        [Description("default-return-policies-area.stock-mistake-clearance")]
        StockMistakeClearance,

        [Description("default-return-policies-area.order-mistake")]
        OrderMistake,

        [Description("default-return-policies-area.instake-mistake")]
        InstakeMistake,

        [Description("default-return-policies-area.miscellaneous")]
        Miscellaneous,

        [Description("default-return-policies-area.cool-box")]
        CoolBox,

        [Description("default-return-policies-area.unsellable-package")]
        UnsellablePackage,

        [Description("default-return-policies-area.expired-too-close-to-expiry-date")]
        ExpiredTooCloseToExpiryDate,

        [Description("default-return-policies-area.for-testing-viewing-purposes")]
        ForTestingViewingPurposes,

        [Description("default-return-policies-area.without-billing")]
        WithoutBilling,

        [Description("default-return-policies-area.product-rebuy")]
        ProductRebuy,

        [Description("default-return-policies-area.call-back")]
        CallBack,

        [Description("default-return-policies-area.doctors-practice-mistake")]
        DoctorsPracticeMistake
    }

    public static partial class ResourceFilePath
    {
        public static String DefaultReturnPolices = "DLCore_DBCommons.APODemand.StaticListDataResource.default-return-policies.xml";
    }
}
