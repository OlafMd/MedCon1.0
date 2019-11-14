using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum EApplicationSettings
    {
        [Description("apo-webshop.hitlist-period")]
        HitlistPeriod,
        [Description("apo-webshop.price-boundary")]
        PriceBoundary,
        [Description("apo-pharmacy.monthly-sales-timespan-in-days")]
        MonthlySalesTimeSpan
         
    }

}
