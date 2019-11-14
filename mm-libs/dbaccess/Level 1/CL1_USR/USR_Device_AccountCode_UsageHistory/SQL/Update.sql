UPDATE 
	usr_device_accountcode_usagehistory
SET 
	Device_AccountCode_RefID=@Device_AccountCode_RefID,
	UsedBy_ExternalAddress=@UsedBy_ExternalAddress,
	UsedBy_BrowserAgent=@UsedBy_BrowserAgent,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_Device_AccountCode_UsageHistoryID = @USR_Device_AccountCode_UsageHistoryID