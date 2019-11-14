UPDATE 
	hec_cas_case_relevantdiagnosisupdates
SET 
	Case_RefID=@Case_RefID,
	PerformedAction_DiagnosisUpdate_RefID=@PerformedAction_DiagnosisUpdate_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_RelevantDiagnosisUpdateID = @HEC_CAS_Case_RelevantDiagnosisUpdateID