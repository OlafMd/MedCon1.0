UPDATE 
	hec_dia_potentialdiagnosis_catalog_access
SET 
	PotentialDiagnosis_Catalog_RefID=@PotentialDiagnosis_Catalog_RefID,
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	IsContributor=@IsContributor,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_PotentialDiagnosis_Catalog_AccessID = @HEC_DIA_PotentialDiagnosis_Catalog_AccessID