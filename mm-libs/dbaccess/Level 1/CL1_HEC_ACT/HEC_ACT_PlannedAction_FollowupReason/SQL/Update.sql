UPDATE 
	hec_act_plannedaction_followupreasons
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	FollowupReason_DictID=@FollowupReason,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PlannedAction_FollowupReasonID = @HEC_ACT_PlannedAction_FollowupReasonID