INSERT INTO 
	hec_act_plannedaction_2_plannedactionfollowupreasons
	(
		AssignmentID,
		HEC_ACT_PlannedAction_RefID,
		HEC_ACT_PlannedAction_FollowupReason_RefID,
		FollowupReason,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@AssignmentID,
		@HEC_ACT_PlannedAction_RefID,
		@HEC_ACT_PlannedAction_FollowupReason_RefID,
		@FollowupReason,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)