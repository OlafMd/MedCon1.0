
	SELECT CMN_SLS_Pricelist.CMN_SLS_PricelistID
		,CMN_SLS_Pricelist.Pricelist_Name_DictID
		,cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID
		,cmn_sls_pricelist_releases.Release_Version
		,cmn_sls_pricelist_releases.PricelistRelease_ValidFrom
    ,cmn_sls_pricelist_releases.PricelistRelease_ValidTo
		,cmn_sls_pricelist_releases.IsPricelistAlwaysActive
		,CMN_SLS_Prices.CMN_SLS_PriceID
		,CMN_SLS_Prices.PriceAmount
		,CMN_SLS_Prices.CMN_Currency_RefID
	FROM CMN_SLS_Pricelist
	LEFT JOIN cmn_sls_pricelist_releases ON CMN_SLS_Pricelist.CMN_SLS_PricelistID = cmn_sls_pricelist_releases.Pricelist_RefID
		AND cmn_sls_pricelist_releases.IsDeleted = 0
		AND cmn_sls_pricelist_releases.Tenant_RefID = @TenantID
	LEFT JOIN CMN_SLS_Prices ON cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID = CMN_SLS_Prices.PricelistRelease_RefID
		AND CMN_SLS_Prices.CMN_PRO_Product_Variant_RefID = @ProductVariantID
		AND CMN_SLS_Prices.IsDeleted = 0
		AND CMN_SLS_Prices.Tenant_RefID = @TenantID
	WHERE 
    cmn_sls_pricelist.IsDeleted = 0
    AND cmn_sls_pricelist.Tenant_RefID = @TenantID
  