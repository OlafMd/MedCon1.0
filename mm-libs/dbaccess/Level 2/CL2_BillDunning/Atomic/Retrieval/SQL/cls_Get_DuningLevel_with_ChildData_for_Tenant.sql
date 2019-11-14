
	SELECT dunning.ACC_DUN_Dunning_LevelID parID
		,dunning.GlobalPropertyMatchingID
		,child.ParentLevel_RefID
		,child.ACC_DUN_Dunning_LevelID childID
		,child.GlobalPropertyMatchingID childGlobalPropertyMatchingID
		,acc_dun_dunninglevel_modelassignments.OrderSequence
		,acc_dun_dunninglevel_modelassignments.DunningFee
		,acc_dun_dunninglevel_modelassignments.WaitPeriodToNextDunningLevel_In_Days
		,acc_dun_dunninglevel_modelassignments.ACC_DUN_DunningLevel_ModelAssignmentID
	FROM acc_dun_dunning_levels dunning
	INNER JOIN acc_dun_dunning_levels child ON dunning.ACC_DUN_Dunning_LevelID = child.ParentLevel_RefID
   AND child.IsDeleted = 0
	LEFT JOIN acc_dun_dunninglevel_modelassignments ON acc_dun_dunninglevel_modelassignments.Dunning_Level_RefID = child.ACC_DUN_Dunning_LevelID
   AND acc_dun_dunninglevel_modelassignments.IsDeleted = 0
	WHERE dunning.IsDeleted = 0 
	AND dunning.Tenant_RefID = @TenantID
  