INSERT INTO 
	usr_device_accountcode_usagehistory
	(
		USR_Device_AccountCode_UsageHistoryID,
		Device_AccountCode_RefID,
		UsedBy_ExternalAddress,
		UsedBy_BrowserAgent,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@USR_Device_AccountCode_UsageHistoryID,
		@Device_AccountCode_RefID,
		@UsedBy_ExternalAddress,
		@UsedBy_BrowserAgent,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)