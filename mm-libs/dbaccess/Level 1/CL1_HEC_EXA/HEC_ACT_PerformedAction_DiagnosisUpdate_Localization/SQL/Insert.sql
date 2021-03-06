INSERT INTO 
	hec_act_performedaction_diagnosisupdate_localizations
	(
		HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID,
		HEX_EXC_Action_DiagnosisUpdate_RefID,
		HEC_DIA_Diagnosis_Localization_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID,
		@HEX_EXC_Action_DiagnosisUpdate_RefID,
		@HEC_DIA_Diagnosis_Localization_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)