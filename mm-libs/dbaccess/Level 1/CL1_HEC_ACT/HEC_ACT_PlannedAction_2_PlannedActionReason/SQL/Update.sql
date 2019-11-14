UPDATE 
	hec_act_plannedaction_2_plannedactionreasons
SET 
	HEC_ACT_PlannedAction_RefID=@HEC_ACT_PlannedAction_RefID,
	HEC_ACT_PlannedAction_Reason_RefID=@HEC_ACT_PlannedAction_Reason_RefID,
	Reason=@Reason,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID