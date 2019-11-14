UPDATE 
	cmn_sls_pricelist_releases
SET 
	Pricelist_RefID=@Pricelist_RefID,
	Release_Version=@Release_Version,
	PricelistRelease_Comment=@PricelistRelease_Comment,
	PricelistRelease_ValidFrom=@PricelistRelease_ValidFrom,
	PricelistRelease_ValidTo=@PricelistRelease_ValidTo,
	IsPricelistAlwaysActive=@IsPricelistAlwaysActive,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_Pricelist_ReleaseID = @CMN_SLS_Pricelist_ReleaseID