INSERT INTO 
	acc_dun_dunningprocesses
	(
		ACC_DUN_DunningProcessID,
		DunnedCustomer_RefID,
		DunningModel_RefID,
		Currency_RefID,
		Current_DunningLevel_RefID,
		DunnedAmount_Total,
		ReachesNextDunningLevelAtDate,
		IsDunningProcessClosed,
		DunningProcessClosedAt_Date,
		DunningProcessClosedBy_BusinessParticipnant_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_DUN_DunningProcessID,
		@DunnedCustomer_RefID,
		@DunningModel_RefID,
		@Currency_RefID,
		@Current_DunningLevel_RefID,
		@DunnedAmount_Total,
		@ReachesNextDunningLevelAtDate,
		@IsDunningProcessClosed,
		@DunningProcessClosedAt_Date,
		@DunningProcessClosedBy_BusinessParticipnant_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)