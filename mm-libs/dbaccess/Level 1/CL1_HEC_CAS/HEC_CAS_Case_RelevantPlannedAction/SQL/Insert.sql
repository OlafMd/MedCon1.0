INSERT INTO 
	hec_cas_case_relevantplannedactions
	(
		HEC_CAS_Case_RelevantPlannedActionID,
		Case_RefID,
		PlannedAction_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CAS_Case_RelevantPlannedActionID,
		@Case_RefID,
		@PlannedAction_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)