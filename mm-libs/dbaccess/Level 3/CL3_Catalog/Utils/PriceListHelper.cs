using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL1_CMN_SLS;

namespace CL3_Catalog.Utils
{
    class PriceListHelper
    {

        public ORM_CMN_SLS_Pricelist CreatePriceListForCatalog(Guid TenantID) {
            ORM_CMN_SLS_Pricelist result = new ORM_CMN_SLS_Pricelist();
            result.CMN_SLS_PricelistID = Guid.NewGuid();
            result.Creation_Timestamp = DateTime.Now;
            result.IsDiscountCalculated_Accumulative = false;
            result.IsDiscountCalculated_Maximum = false;
            result.Tenant_RefID = TenantID;
            return result;
        }

        public ORM_CMN_SLS_Pricelist_Release CreatePriceListReleaseForCatalog(Guid TenantID, Guid PricelistID)
        {
            ORM_CMN_SLS_Pricelist_Release result = new ORM_CMN_SLS_Pricelist_Release();
            result.CMN_SLS_Pricelist_ReleaseID = Guid.NewGuid();
            result.Creation_Timestamp = DateTime.Now;
            result.Pricelist_RefID = PricelistID;
            result.Release_Version = "0";
            result.Tenant_RefID = TenantID;
            return result;
        }

    }
}
