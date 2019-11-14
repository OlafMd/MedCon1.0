INSERT INTO 
	res_act_action_version
	(
		RES_ACT_Action_VersionID,
		Action_RefID,
		Action_Name_DictID,
		Action_Description_DictID,
		Action_Version,
		Default_PricePerUnit_RefID,
		Default_Unit_RefID,
		Default_UnitAmount,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_ACT_Action_VersionID,
		@Action_RefID,
		@Action_Name,
		@Action_Description,
		@Action_Version,
		@Default_PricePerUnit_RefID,
		@Default_Unit_RefID,
		@Default_UnitAmount,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)