UPDATE 
	hec_potentialmedications
SET 
	IsHealthcareProduct=@IsHealthcareProduct,
	HEC_Product_RefID=@HEC_Product_RefID,
	IsSubstance=@IsSubstance,
	IfSubstance_Strength=@IfSubstance_Strength,
	IfSubstance_Unit_RefID=@IfSubstance_Unit_RefID,
	HEC_SUB_Substance_RefiD=@HEC_SUB_Substance_RefiD,
	RecommendedDosage=@RecommendedDosage,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_PotentialMedicationID = @HEC_PotentialMedicationID