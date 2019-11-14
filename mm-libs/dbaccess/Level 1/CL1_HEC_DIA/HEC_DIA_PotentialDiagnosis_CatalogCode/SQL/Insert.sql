INSERT INTO 
	hec_dia_potentialdiagnosis_catalogcodes
	(
		HEC_DIA_PotentialDiagnosis_CatalogCodeID,
		PotentialDiagnosis_RefID,
		PotentialDiagnosis_Catalog_RefID,
		Code,
		Creation_Timestamp,
		Modification_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@HEC_DIA_PotentialDiagnosis_CatalogCodeID,
		@PotentialDiagnosis_RefID,
		@PotentialDiagnosis_Catalog_RefID,
		@Code,
		@Creation_Timestamp,
		@Modification_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)