
  Select
    cmn_sls_pricelist.Pricelist_Name_DictID,
    cmn_sls_pricelist.CMN_SLS_PricelistID,
    cmn_sls_prices.CMN_SLS_PriceID,
    cmn_sls_prices.PriceAmount,
    cmn_sls_pricelist_releases.Release_Version,
    cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID,
    cmn_sls_prices.CMN_PRO_Product_RefID,
    cmn_sls_prices.CMN_Currency_RefID,
    cmn_sls_prices.IsDynamicPricingUsed,
    cmn_sls_prices.DynamicPricingFormula_Type_RefID,
    cmn_sls_prices.DynamicPricingFormula,
    cmn_sls_pricelist.GlobalPropertyMatchingID
  From
    cmn_sls_pricelist_releases Left Join
    cmn_sls_prices On cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID =
      cmn_sls_prices.PricelistRelease_RefID And
      cmn_sls_prices.CMN_PRO_Product_RefID = @ArticleID And
      cmn_sls_prices.CMN_Currency_RefID = @CurrencyID Inner Join
    cmn_sls_pricelist On cmn_sls_pricelist_releases.Pricelist_RefID =
      cmn_sls_pricelist.CMN_SLS_PricelistID
  Where
    cmn_sls_pricelist_releases.IsDeleted = 0 And
    cmn_sls_pricelist_releases.Tenant_RefID = @TenantID
  