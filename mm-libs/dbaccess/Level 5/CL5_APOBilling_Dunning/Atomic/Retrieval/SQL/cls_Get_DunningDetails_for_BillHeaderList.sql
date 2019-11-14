
	Select
  acc_dun_dunningprocess_memberbills.ACC_DUN_DunningProcess_MemberBillID,
  acc_dun_dunningprocess_memberbills.BIL_BillHeader_RefID,
  acc_dun_dunningprocess_memberbills.ApplicableProcessDunningFees,
  acc_dun_dunningprocess_memberbills.CurrentUnpaidBillFraction,
  acc_dun_dunningprocesses.ACC_DUN_DunningProcessID,
  acc_dun_dunning_models.ACC_DUN_Dunning_ModelID,
  acc_dun_dunningprocesses.IsDunningProcessClosed,
  acc_dun_dunningprocess_history.IsCurrentStep,
  acc_dun_dunningprocess_history.IsSentToCustomer,
  acc_dun_dunningprocess_history.ACC_DUN_DunningProcess_HistoryID,
  acc_dun_dunningprocesses.DunnedAmount_Total,
  acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID,
  acc_dun_dunningprocesses.DunningProcessClosedAt_Date,
  acc_dun_dunningprocesses.DunningProcessClosedBy_BusinessParticipnant_RefID,
  acc_dun_dunning_levels.Default_DunningFee,
  acc_dun_dunningprocesses.ReachesNextDunningLevelAtDate,
  acc_dun_dunninglevel_modelassignments.OrderSequence,
  acc_dun_dunninglevel_modelassignments.DunningFee,
  acc_dun_dunninglevel_modelassignments.ACC_DUN_DunningLevel_ModelAssignmentID,
  acc_dun_dunning_levels.GlobalPropertyMatchingID,
  acc_dun_dunning_levels.DunningLevelName_DictID
From
  acc_dun_dunning_models Inner Join
  acc_dun_dunningprocesses On acc_dun_dunning_models.ACC_DUN_Dunning_ModelID =
    acc_dun_dunningprocesses.DunningModel_RefID Inner Join
  acc_dun_dunningprocess_memberbills
    On acc_dun_dunningprocesses.ACC_DUN_DunningProcessID =
    acc_dun_dunningprocess_memberbills.ACC_DUN_DunningProcess_RefID Inner Join
  acc_dun_dunning_levels On acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID =
    acc_dun_dunningprocesses.Current_DunningLevel_RefID Inner Join
  acc_dun_dunningprocess_history
    On acc_dun_dunningprocess_memberbills.ACC_DUN_DunningProcess_RefID =
    acc_dun_dunningprocess_history.ACC_DUN_DunningProcess_RefID And
    acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID =
    acc_dun_dunningprocess_history.ACC_DUN_Dunning_Level_RefID Inner Join
  acc_dun_dunninglevel_modelassignments
    On acc_dun_dunning_models.ACC_DUN_Dunning_ModelID =
    acc_dun_dunninglevel_modelassignments.Dunning_Model_RefID And
    acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID =
    acc_dun_dunninglevel_modelassignments.Dunning_Level_RefID And
    acc_dun_dunninglevel_modelassignments.IsDeleted = 0
Where
  acc_dun_dunningprocess_memberbills.BIL_BillHeader_RefID = @BillHeaderID_List And
  acc_dun_dunningprocesses.IsDunningProcessClosed = 0 And
  acc_dun_dunningprocess_memberbills.Tenant_RefID = @TenantID And
  acc_dun_dunningprocess_memberbills.IsDeleted = 0 And
  acc_dun_dunningprocess_history.IsCurrentStep = 1 And
  (@BillDunningStatusGlobalProperty IS NULL OR (@BillDunningStatusGlobalProperty IS NOT NULL AND acc_dun_dunning_levels.GlobalPropertyMatchingID = @BillDunningStatusGlobalProperty)) 
  AND (@DunningDateFrom IS NULL OR (@DunningDateFrom IS NOT NULL AND acc_dun_dunningprocesses.ReachesNextDunningLevelAtDate >= @DunningDateFrom))
  AND (@DunningDateTo IS NULL OR (@DunningDateTo IS NOT NULL AND acc_dun_dunningprocesses.ReachesNextDunningLevelAtDate <= @DunningDateTo))
  AND acc_dun_dunningprocess_history.IsSentToCustomer = IfNull(@IsReminded, acc_dun_dunningprocess_history.IsSentToCustomer)
  AND acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID = IfNull(@DunningLevelID, acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID)
  