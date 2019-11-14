UPDATE 
	hec_dia_diagnosis_localizations
SET 
	Diagnosis_RefID=@Diagnosis_RefID,
	LocalizationCode=@LocalizationCode,
	DiagnosisLocalization_Name_DictID=@DiagnosisLocalization_Name,
	DiagnosisLocalization_Description_DictID=@DiagnosisLocalization_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_Diagnosis_LocalizationID = @HEC_DIA_Diagnosis_LocalizationID