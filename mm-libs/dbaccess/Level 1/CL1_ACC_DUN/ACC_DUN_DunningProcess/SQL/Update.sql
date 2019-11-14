UPDATE 
	acc_dun_dunningprocesses
SET 
	DunnedCustomer_RefID=@DunnedCustomer_RefID,
	DunningModel_RefID=@DunningModel_RefID,
	Currency_RefID=@Currency_RefID,
	Current_DunningLevel_RefID=@Current_DunningLevel_RefID,
	DunnedAmount_Total=@DunnedAmount_Total,
	ReachesNextDunningLevelAtDate=@ReachesNextDunningLevelAtDate,
	IsDunningProcessClosed=@IsDunningProcessClosed,
	DunningProcessClosedAt_Date=@DunningProcessClosedAt_Date,
	DunningProcessClosedBy_BusinessParticipnant_RefID=@DunningProcessClosedBy_BusinessParticipnant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_DUN_DunningProcessID = @ACC_DUN_DunningProcessID