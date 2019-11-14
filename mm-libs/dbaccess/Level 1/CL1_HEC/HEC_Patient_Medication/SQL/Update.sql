UPDATE 
	hec_patient_medications
SET 
	Patient_RefID=@Patient_RefID,
	R_IsActive=@R_IsActive,
	R_ActiveUntill=@R_ActiveUntill,
	R_DateOfAdding=@R_DateOfAdding,
	R_DateOfRemoval=@R_DateOfRemoval,
	R_IsHealthcareProduct=@R_IsHealthcareProduct,
	R_HEC_Product_RefID=@R_HEC_Product_RefID,
	R_IsSubstance=@R_IsSubstance,
	R_IfSubstance_Strength=@R_IfSubstance_Strength,
	R_IfSubstance_Unit_RefID=@R_IfSubstance_Unit_RefID,
	R_IfSubstance_Substance_RefiD=@R_IfSubstance_Substance_RefiD,
	R_DosageText=@R_DosageText,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_MedicationID = @HEC_Patient_MedicationID