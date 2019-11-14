UPDATE 
	hec_cas_case_relevantprocedures
SET 
	Case_RefID=@Case_RefID,
	PerfomedAction_Procedure_RefID=@PerfomedAction_Procedure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_RelevantProcedureID = @HEC_CAS_Case_RelevantProcedureID