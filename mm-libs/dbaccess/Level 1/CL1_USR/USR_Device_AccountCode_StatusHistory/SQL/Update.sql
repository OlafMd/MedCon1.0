UPDATE 
	usr_device_accountcode_statushistory
SET 
	Device_AccountCode_RefID=@Device_AccountCode_RefID,
	IsAccountCode_Active=@IsAccountCode_Active,
	IsAccountCode_Revoked=@IsAccountCode_Revoked,
	IsAccountCode_Banned=@IsAccountCode_Banned,
	IsAccountCode_Disabled=@IsAccountCode_Disabled,
	IsAccountCode_Expired=@IsAccountCode_Expired,
	IsAccountCode_UsageLimitReached=@IsAccountCode_UsageLimitReached,
	AccountCode_StatusComment=@AccountCode_StatusComment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_Device_AccountCode_StatusHistoryID = @USR_Device_AccountCode_StatusHistoryID