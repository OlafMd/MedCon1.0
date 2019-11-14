UPDATE 
	res_act_action
SET 
	ActionType_RefID=@ActionType_RefID,
	CurrentVersion_RefID=@CurrentVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_ACT_ActionID = @RES_ACT_ActionID