
	Select
	  cmn_sls_pricelist_releases.PricelistRelease_Comment,
	  cmn_sls_pricelist_releases.PricelistRelease_ValidFrom,
	  cmn_sls_pricelist_releases.PricelistRelease_ValidTo,
	  cmn_sls_pricelist_releases.Release_Version,
	  cmn_sls_pricelist_releases.Pricelist_RefID,
	  cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID
	From
	  cmn_sls_pricelist_releases
	Where
	  cmn_sls_pricelist_releases.Pricelist_RefID = IfNull(@PricelistID, cmn_sls_pricelist_releases.Pricelist_RefID) And
	  cmn_sls_pricelist_releases.Tenant_RefID = @TenantID And
	  cmn_sls_pricelist_releases.IsDeleted = 0
  