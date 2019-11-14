
Select
  cmn_sls_pricelist.CMN_SLS_PricelistID,
  cmn_sls_pricelist.Pricelist_Name_DictID,
  cmn_sls_pricelist.Pricelist_Description_DictID,
  cmn_sls_pricelist.IsDiscountCalculated_Maximum,
  cmn_sls_pricelist.IsDiscountCalculated_Accumulative,
  cmn_tenants.Customers_DefaultPricelist_RefID,
  cmn_sls_pricelist.GlobalPropertyMatchingID
From
  cmn_sls_pricelist Left Join
  cmn_tenants On cmn_sls_pricelist.CMN_SLS_PricelistID =
    cmn_tenants.Customers_DefaultPricelist_RefID
Where
  cmn_sls_pricelist.CMN_SLS_PricelistID = IfNull(@PricelistID, cmn_sls_pricelist.CMN_SLS_PricelistID) And
  cmn_sls_pricelist.IsDeleted = 0 And
  cmn_sls_pricelist.Tenant_RefID = @TenantID
  