UPDATE 
	acc_dun_dunning_levels
SET 
	ParentLevel_RefID=@ParentLevel_RefID,
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DunningLevelName_DictID=@DunningLevelName,
	OrderSequence=@OrderSequence,
	Default_DunningFee=@Default_DunningFee,
	Default_Configuration=@Default_Configuration,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_DUN_Dunning_LevelID = @ACC_DUN_Dunning_LevelID