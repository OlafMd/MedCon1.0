UPDATE 
	hec_dia_recommendedsubstance_dosages
SET 
	RecommendedSubstance_RefID=@RecommendedSubstance_RefID,
	Dosage_RefID=@Dosage_RefID,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_RecommendedSubstance_DosageID = @HEC_DIA_RecommendedSubstance_DosageID