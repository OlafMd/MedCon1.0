
	SELECT 
  acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID
  , acc_dun_dunning_levels.Creation_Timestamp
  , acc_dun_dunning_levels.Default_Configuration
  , acc_dun_dunning_levels.Default_DunningFee
  , acc_dun_dunning_levels.DunningLevelName_DictID
  , acc_dun_dunning_levels.GlobalPropertyMatchingID
  , acc_dun_dunning_levels.IsDeleted
  , acc_dun_dunning_levels.OrderSequence
  , acc_dun_dunning_levels.ParentLevel_RefID
  , acc_dun_dunning_levels.Tenant_RefID
	FROM acc_dun_dunning_levels
	WHERE 
	acc_dun_dunning_levels.Tenant_RefID = @TenantID
	AND acc_dun_dunning_levels.IsDeleted = 0
  