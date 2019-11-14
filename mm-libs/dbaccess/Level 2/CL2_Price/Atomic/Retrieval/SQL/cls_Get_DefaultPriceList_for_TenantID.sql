
SELECT cmn_tenants.Customers_DefaultPricelist_RefID as DefaultPriceListID
  FROM cmn_tenants where cmn_tenants.CMN_TenantID=@TenantID
  