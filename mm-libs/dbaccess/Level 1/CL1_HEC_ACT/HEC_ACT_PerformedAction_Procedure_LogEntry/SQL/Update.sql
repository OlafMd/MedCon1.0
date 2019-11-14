UPDATE 
	hec_act_performedaction_procedure_logentries
SET 
	Triggering_BusinessParticipant_RefID=@Triggering_BusinessParticipant_RefID,
	Action_Procedure_RefID=@Action_Procedure_RefID,
	DateOfEntry=@DateOfEntry,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_Procedure_LogEntryID = @HEC_ACT_PerformedAction_Procedure_LogEntryID