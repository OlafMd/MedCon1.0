INSERT INTO 
	usr_device_accountcode_statushistory
	(
		USR_Device_AccountCode_StatusHistoryID,
		Device_AccountCode_RefID,
		IsAccountCode_Active,
		IsAccountCode_Revoked,
		IsAccountCode_Banned,
		IsAccountCode_Disabled,
		IsAccountCode_Expired,
		IsAccountCode_UsageLimitReached,
		AccountCode_StatusComment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@USR_Device_AccountCode_StatusHistoryID,
		@Device_AccountCode_RefID,
		@IsAccountCode_Active,
		@IsAccountCode_Revoked,
		@IsAccountCode_Banned,
		@IsAccountCode_Disabled,
		@IsAccountCode_Expired,
		@IsAccountCode_UsageLimitReached,
		@AccountCode_StatusComment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)