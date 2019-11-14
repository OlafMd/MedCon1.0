UPDATE 
	acc_dun_dunningprocess_history
SET 
	ACC_DUN_DunningProcess_RefID=@ACC_DUN_DunningProcess_RefID,
	ACC_DUN_Dunning_Level_RefID=@ACC_DUN_Dunning_Level_RefID,
	DunningProcessFee_IncludingThisDunningLevel=@DunningProcessFee_IncludingThisDunningLevel,
	IsCurrentStep=@IsCurrentStep,
	TriggeredBy_BusinessParticipant_RefID=@TriggeredBy_BusinessParticipant_RefID,
	TriggeredAt_Date=@TriggeredAt_Date,
	IsSentToCustomer=@IsSentToCustomer,
	SendToCustomerBy_BusinessParticipant_RefID=@SendToCustomerBy_BusinessParticipant_RefID,
	SendToCustomerAt_Date=@SendToCustomerAt_Date,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_DUN_DunningProcess_HistoryID = @ACC_DUN_DunningProcess_HistoryID