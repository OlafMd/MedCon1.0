UPDATE 
	hec_cas_case_relevantplannedactions
SET 
	Case_RefID=@Case_RefID,
	PlannedAction_RefID=@PlannedAction_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_RelevantPlannedActionID = @HEC_CAS_Case_RelevantPlannedActionID