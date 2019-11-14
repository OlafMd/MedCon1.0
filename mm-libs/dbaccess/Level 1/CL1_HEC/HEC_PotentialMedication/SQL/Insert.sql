INSERT INTO 
	hec_potentialmedications
	(
		HEC_PotentialMedicationID,
		IsHealthcareProduct,
		HEC_Product_RefID,
		IsSubstance,
		IfSubstance_Strength,
		IfSubstance_Unit_RefID,
		HEC_SUB_Substance_RefiD,
		RecommendedDosage,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@HEC_PotentialMedicationID,
		@IsHealthcareProduct,
		@HEC_Product_RefID,
		@IsSubstance,
		@IfSubstance_Strength,
		@IfSubstance_Unit_RefID,
		@HEC_SUB_Substance_RefiD,
		@RecommendedDosage,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)