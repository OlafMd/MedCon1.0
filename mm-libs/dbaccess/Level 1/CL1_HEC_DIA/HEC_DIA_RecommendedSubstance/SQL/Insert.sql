INSERT INTO 
	hec_dia_recommendedsubstances
	(
		HEC_DIA_RecommendedSubstanceID,
		PotentialDiagnosis_RefID,
		Substance_RefID,
		SubstanceStrength,
		Substance_Unit_RefID,
		IsDefault,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_DIA_RecommendedSubstanceID,
		@PotentialDiagnosis_RefID,
		@Substance_RefID,
		@SubstanceStrength,
		@Substance_Unit_RefID,
		@IsDefault,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)