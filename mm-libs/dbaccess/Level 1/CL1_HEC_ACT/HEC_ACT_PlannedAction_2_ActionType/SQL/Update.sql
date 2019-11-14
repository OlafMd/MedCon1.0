UPDATE 
	hec_act_plannedaction_2_actiontype
SET 
	HEC_ACT_PlannedAction_RefID=@HEC_ACT_PlannedAction_RefID,
	HEC_ACT_ActionType_RefID=@HEC_ACT_ActionType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PlannedAction_2_ActionTypeID = @HEC_ACT_PlannedAction_2_ActionTypeID