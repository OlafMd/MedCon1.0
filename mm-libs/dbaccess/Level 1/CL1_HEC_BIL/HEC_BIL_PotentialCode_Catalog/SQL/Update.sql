UPDATE 
	hec_bil_potentialcode_catalogs
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DateOfPublishing=@DateOfPublishing,
	CatalogName_DictID=@CatalogName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_BIL_PotentialCode_CatalogID = @HEC_BIL_PotentialCode_CatalogID