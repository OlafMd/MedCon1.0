
	Select
	  cmn_sls_prices.CMN_PRO_Product_RefID,
	  cmn_sls_prices.PriceAmount,
	  cmn_currencies.Symbol
	From
	  cmn_sls_pricelist_releases Inner Join
	  cmn_sls_prices On cmn_sls_prices.PricelistRelease_RefID =
	    cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID Inner Join
	  cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
	    cmn_currencies.CMN_CurrencyID Inner Join
	  cmn_pro_subscribedcatalogs
	    On cmn_pro_subscribedcatalogs.SubscribedCatalog_PricelistRelease_RefID =
	    cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID
	Where
	  cmn_pro_subscribedcatalogs.Tenant_RefID = @TenantID And
	  cmn_pro_subscribedcatalogs.CatalogCodeITL = @SubscribedCatalogITL And
	  cmn_pro_subscribedcatalogs.IsDeleted = 0 And
	  cmn_sls_pricelist_releases.IsDeleted = 0 And
	  cmn_sls_prices.IsDeleted = 0
  