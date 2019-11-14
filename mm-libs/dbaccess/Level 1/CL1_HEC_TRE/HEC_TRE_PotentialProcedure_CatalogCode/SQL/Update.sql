UPDATE 
	hec_tre_potentialprocedure_catalogcodes
SET 
	PotentialProcedure_RefID=@PotentialProcedure_RefID,
	PotentialProcedure_Catalog_RefID=@PotentialProcedure_Catalog_RefID,
	Code=@Code,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_TRE_PotentialProcedure_CatalogCodeID = @HEC_TRE_PotentialProcedure_CatalogCodeID