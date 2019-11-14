UPDATE 
	res_act_action_version
SET 
	Action_RefID=@Action_RefID,
	Action_Name_DictID=@Action_Name,
	Action_Description_DictID=@Action_Description,
	Action_Version=@Action_Version,
	Default_PricePerUnit_RefID=@Default_PricePerUnit_RefID,
	Default_Unit_RefID=@Default_Unit_RefID,
	Default_UnitAmount=@Default_UnitAmount,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_ACT_Action_VersionID = @RES_ACT_Action_VersionID