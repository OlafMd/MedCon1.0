UPDATE 
	hec_act_performedaction_procedure_participants
SET 
	Action_Procedure_RefID=@Action_Procedure_RefID,
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_Procedure_ParticipantID = @HEC_ACT_PerformedAction_Procedure_ParticipantID