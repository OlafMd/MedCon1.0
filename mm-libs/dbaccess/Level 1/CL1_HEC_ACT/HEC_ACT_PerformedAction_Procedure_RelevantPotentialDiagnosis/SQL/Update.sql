UPDATE 
	hec_act_performedaction_procedure_relevantpotentialdiagnoses
SET 
	Action_Procedure_RefID=@Action_Procedure_RefID,
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	Diagnosis_Localization_RefID=@Diagnosis_Localization_RefID,
	Diagnosis_State_RefID=@Diagnosis_State_RefID,
	DiagnosedOnDate=@DiagnosedOnDate,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_Procedure_RelevantPotentialDiagnosisID = @HEC_ACT_PerformedAction_Procedure_RelevantPotentialDiagnosisID