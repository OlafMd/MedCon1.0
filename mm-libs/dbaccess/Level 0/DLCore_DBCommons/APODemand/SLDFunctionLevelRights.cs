using System;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EAccountFunctionLevelRight
    {
        [Description("account-function-level-right.apo-admin-access")]
        APOAdminAccess,
        [Description("account-function-level-right.apo-backoffice-access")]
        APOBackofficeAccess,
        [Description("account-function-level-right.apo-billing-access")]
        APOBillingAccess,
        [Description("account-function-level-right.apo-billing-change-bill-position-prices")]
        APOBillingChangeBillPositionPrices,
        [Description("account-function-level-right.apo-customeradmin-access")]
        APOCustomerAdminAccess,
        [Description("account-function-level-right.apo-logistic-access")]
        APOLogisticAccess,
        [Description("account-function-level-right.apo-logistic-change-shipment-prices")]
        APOLogisticChangeShipmentPrices,
        [Description("account-function-level-right.apo-logistic-delete-inventory")]
        APOLogisticDeleteInventory,
        [Description("account-function-level-right.apo-procurement-access")]
        APOProcurementAccess,
        [Description("account-function-level-right.apo-webshop-level1")]
        APOWebShopLevel1,
        [Description("account-function-level-right.apo-webshop-level2")]
        APOWebShopLevel2,
        [Description("account-function-level-right.apo-webshop-level3")]
        APOWebShopLevel3
    }

    public enum EAccountFunctionLevelRightGroup
    {
        [Description("account-function-level-rights_group.apo-admin")]
        APOAdmin,
        [Description("account-function-level-rights_group.apo-webshop")]
        APOWebShop,
        [Description("account-function-level-rights_group.apo-backoffice")]
        APOBackoffice,
        [Description("account-function-level-rights_group.apo-billing")]
        APOBilling,
        [Description("account-function-level-rights_group.apo-customeradmin")]
        APOCustomerAdmin,
        [Description("account-function-level-rights_group.apo-logistic")]
        APOLogistic,
        [Description("account-function-level-rights_group.apo-procurement")]
        APOProcurement
    }

    public static partial class ResourceFilePath
    {
        public static String AccountFunctionLevelRight = "DLCore_DBCommons.APODemand.StaticListDataResource.acount-function-level-right.xml";
        public static String AccountFunctionLevelRightGroup = "DLCore_DBCommons.APODemand.StaticListDataResource.acount-function-level-right-group.xml";
    }
}
