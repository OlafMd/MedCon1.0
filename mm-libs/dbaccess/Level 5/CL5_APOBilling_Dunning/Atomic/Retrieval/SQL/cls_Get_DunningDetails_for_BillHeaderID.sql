
	Select
	  acc_dun_dunningprocess_memberbills.ACC_DUN_DunningProcess_MemberBillID,
	  acc_dun_dunningprocess_memberbills.BIL_BillHeader_RefID,
	  acc_dun_dunningprocess_memberbills.ApplicableProcessDunningFees,
	  acc_dun_dunningprocess_memberbills.CurrentUnpaidBillFraction,
	  acc_dun_dunningprocesses.ACC_DUN_DunningProcessID,
	  acc_dun_dunning_models.ACC_DUN_Dunning_ModelID
	From
	  acc_dun_dunning_models Inner Join
	  acc_dun_dunningprocesses On acc_dun_dunning_models.ACC_DUN_Dunning_ModelID =
	    acc_dun_dunningprocesses.DunningModel_RefID Inner Join
	  acc_dun_dunningprocess_memberbills
	    On acc_dun_dunningprocesses.ACC_DUN_DunningProcessID =
	    acc_dun_dunningprocess_memberbills.ACC_DUN_DunningProcess_RefID Inner Join
	  acc_dun_dunning_levels On acc_dun_dunning_levels.ACC_DUN_Dunning_LevelID =
	    acc_dun_dunningprocesses.Current_DunningLevel_RefID
	Where
	  acc_dun_dunningprocess_memberbills.BIL_BillHeader_RefID = @BillHeader And 
	  acc_dun_dunningprocess_memberbills.Tenant_RefID = @TenantID
  