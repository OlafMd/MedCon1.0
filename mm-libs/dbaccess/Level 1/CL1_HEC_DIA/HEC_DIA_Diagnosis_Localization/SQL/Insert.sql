INSERT INTO 
	hec_dia_diagnosis_localizations
	(
		HEC_DIA_Diagnosis_LocalizationID,
		Diagnosis_RefID,
		LocalizationCode,
		DiagnosisLocalization_Name_DictID,
		DiagnosisLocalization_Description_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_DIA_Diagnosis_LocalizationID,
		@Diagnosis_RefID,
		@LocalizationCode,
		@DiagnosisLocalization_Name,
		@DiagnosisLocalization_Description,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)