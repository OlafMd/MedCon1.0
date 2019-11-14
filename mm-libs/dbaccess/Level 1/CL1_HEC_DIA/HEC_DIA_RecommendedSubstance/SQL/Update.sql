UPDATE 
	hec_dia_recommendedsubstances
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	Substance_RefID=@Substance_RefID,
	SubstanceStrength=@SubstanceStrength,
	Substance_Unit_RefID=@Substance_Unit_RefID,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_RecommendedSubstanceID = @HEC_DIA_RecommendedSubstanceID