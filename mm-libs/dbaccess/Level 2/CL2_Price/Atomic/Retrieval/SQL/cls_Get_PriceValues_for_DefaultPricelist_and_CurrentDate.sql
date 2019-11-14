
	Select
	  cmn_sls_prices.CMN_PRO_Product_RefID,
	  cmn_sls_prices.PriceAmount,
	  cmn_currencies.Symbol,
	  cmn_sls_prices.IsDynamicPricingUsed,
	  cmn_sls_prices.DynamicPricingFormula_Type_RefID,
	  cmn_sls_prices.DynamicPricingFormula
	From
	  cmn_sls_pricelist_releases Inner Join
	  cmn_sls_prices On cmn_sls_prices.PricelistRelease_RefID =
	    cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID Inner Join
	  cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
	    cmn_currencies.CMN_CurrencyID Inner Join
	  cmn_sls_pricelist On cmn_sls_pricelist_releases.Pricelist_RefID =
	    cmn_sls_pricelist.CMN_SLS_PricelistID Inner Join
	  cmn_tenants On cmn_tenants.Customers_DefaultPricelist_RefID =
	    cmn_sls_pricelist.CMN_SLS_PricelistID
	Where
	  cmn_sls_pricelist_releases.IsDeleted = 0 And
	  cmn_sls_prices.IsDeleted = 0 And
	  cmn_sls_pricelist.IsDeleted = 0 And
	  Now() Between cmn_sls_pricelist_releases.PricelistRelease_ValidFrom And
	  cmn_sls_pricelist_releases.PricelistRelease_ValidTo And
	  cmn_tenants.CMN_TenantID = @TenantID
  