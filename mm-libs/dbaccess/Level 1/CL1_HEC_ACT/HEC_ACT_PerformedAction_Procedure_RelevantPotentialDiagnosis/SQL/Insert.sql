INSERT INTO 
	hec_act_performedaction_procedure_relevantpotentialdiagnoses
	(
		HEC_ACT_PerformedAction_Procedure_RelevantPotentialDiagnosisID,
		Action_Procedure_RefID,
		PotentialDiagnosis_RefID,
		Diagnosis_Localization_RefID,
		Diagnosis_State_RefID,
		DiagnosedOnDate,
		Comment,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_ACT_PerformedAction_Procedure_RelevantPotentialDiagnosisID,
		@Action_Procedure_RefID,
		@PotentialDiagnosis_RefID,
		@Diagnosis_Localization_RefID,
		@Diagnosis_State_RefID,
		@DiagnosedOnDate,
		@Comment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)