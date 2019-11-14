UPDATE 
	hec_act_plannedaction_2_plannedactionfollowupreasons
SET 
	HEC_ACT_PlannedAction_RefID=@HEC_ACT_PlannedAction_RefID,
	HEC_ACT_PlannedAction_FollowupReason_RefID=@HEC_ACT_PlannedAction_FollowupReason_RefID,
	FollowupReason=@FollowupReason,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID