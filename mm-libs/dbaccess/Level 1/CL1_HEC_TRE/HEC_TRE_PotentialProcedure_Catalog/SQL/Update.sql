UPDATE 
	hec_tre_potentialprocedure_catalogs
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Catalog_DisplayName=@Catalog_DisplayName,
	Catalog_Name_DictID=@Catalog_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_TRE_PotentialProcedure_CatalogID = @HEC_TRE_PotentialProcedure_CatalogID