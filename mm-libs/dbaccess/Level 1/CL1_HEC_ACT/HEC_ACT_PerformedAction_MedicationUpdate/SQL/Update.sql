UPDATE 
	hec_act_performedaction_medicationupdates
SET 
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	HEC_Patient_Medication_RefID=@HEC_Patient_Medication_RefID,
	Relevant_PatientDiagnosis_RefID=@Relevant_PatientDiagnosis_RefID,
	IsMedicationCreated=@IsMedicationCreated,
	IsMedicationModified=@IsMedicationModified,
	IsMedicationDeactivated=@IsMedicationDeactivated,
	IsHealthcareProduct=@IsHealthcareProduct,
	HEC_Product_RefID=@HEC_Product_RefID,
	IsSubstance=@IsSubstance,
	IfSubstance_Strength=@IfSubstance_Strength,
	IfSubstance_Unit_RefID=@IfSubstance_Unit_RefID,
	IfSubstance_Substance_RefiD=@IfSubstance_Substance_RefiD,
	DosageText=@DosageText,
	IntendedApplicationDuration_in_days=@IntendedApplicationDuration_in_days,
	MedicationUpdateComment=@MedicationUpdateComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_MedicationUpdateID = @HEC_ACT_PerformedAction_MedicationUpdateID