
	SELECT
	  COUNT( *) numberOfReleases
	FROM
	  CMN_SLS_Pricelist
	  INNER JOIN CMN_SLS_Pricelist_Releases
	    ON cmn_sls_pricelist.CMN_SLS_PricelistID =
	         cmn_sls_pricelist_releases.Pricelist_RefID AND
	       CMN_SLS_Pricelist_Releases.IsDeleted = 0 AND
	       CMN_SLS_Pricelist_Releases.Tenant_RefID = @TenantID
	WHERE
	  CMN_SLS_Pricelist.IsDeleted = 0 AND
	  CMN_SLS_Pricelist.Tenant_RefID = @TenantID
  