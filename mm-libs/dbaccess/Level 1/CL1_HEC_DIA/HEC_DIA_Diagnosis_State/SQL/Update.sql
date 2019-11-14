UPDATE 
	hec_dia_diagnosis_states
SET 
	Diagnose_RefID=@Diagnose_RefID,
	DiagnosisState_Abbreviation=@DiagnosisState_Abbreviation,
	Modification_Timestamp=@Modification_Timestamp,
	DiagnosisState_Name_DictID=@DiagnosisState_Name,
	DiagnosisState_Description_DictID=@DiagnosisState_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DIA_Diagnosis_StateID = @HEC_DIA_Diagnosis_StateID