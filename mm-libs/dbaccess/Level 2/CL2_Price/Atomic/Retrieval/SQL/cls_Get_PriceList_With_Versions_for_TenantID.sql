
	SELECT cmn_sls_pricelist.CMN_SLS_PricelistID,
	       cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID,
	       cmn_sls_pricelist.Pricelist_Name_DictID,
	       cmn_sls_pricelist_releases.Release_Version
	FROM
	  cmn_sls_pricelist
	  INNER JOIN cmn_sls_pricelist_releases
	    ON cmn_sls_pricelist.CMN_SLS_PricelistID = cmn_sls_pricelist_releases.Pricelist_RefID AND cmn_sls_pricelist_releases.IsDeleted = 0
	where cmn_sls_pricelist.IsDeleted = 0 AND cmn_sls_pricelist.Tenant_RefID = @TenantID