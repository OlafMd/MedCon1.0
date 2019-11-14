UPDATE 
	hec_dia_potentialdiagnosis_catalogcodes
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	PotentialDiagnosis_Catalog_RefID=@PotentialDiagnosis_Catalog_RefID,
	Code=@Code,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DIA_PotentialDiagnosis_CatalogCodeID = @HEC_DIA_PotentialDiagnosis_CatalogCodeID