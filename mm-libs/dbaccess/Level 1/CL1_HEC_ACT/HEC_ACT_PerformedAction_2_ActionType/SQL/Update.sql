UPDATE 
	hec_act_performedaction_2_actiontype
SET 
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	HEC_ACT_ActionType_RefID=@HEC_ACT_ActionType_RefID,
	IM_ActionType_Name=@IM_ActionType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID