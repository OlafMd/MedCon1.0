UPDATE 
	hec_patient_diagnosis_localizations
SET 
	Patient_Diagnosis_RefID=@Patient_Diagnosis_RefID,
	DIA_Diagnosis_Localization_RefID=@DIA_Diagnosis_Localization_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_Diagnosis_LocalizationID = @HEC_Patient_Diagnosis_LocalizationID