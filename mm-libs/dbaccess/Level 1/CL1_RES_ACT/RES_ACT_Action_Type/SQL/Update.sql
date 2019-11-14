UPDATE 
	res_act_action_types
SET 
	ActionType_Name_DictID=@ActionType_Name,
	ActionType_Description_DictID=@ActionType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_ACT_Action_TypeID = @RES_ACT_Action_TypeID