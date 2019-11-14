INSERT INTO 
	usr_device_accountcodes
	(
		USR_Device_AccountCodeID,
		Account_RefID,
		AccountCode_Value,
		AccountCode_ValidFrom,
		AccountCode_ValidTo,
		IsAccountCode_Expirable,
		AccountCode_CurrentStatus_RefID,
		AccountCode_NumberOfAccesses_MaximumValue,
		AccountCode_NumberOfAccesses_CurrentValue,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@USR_Device_AccountCodeID,
		@Account_RefID,
		@AccountCode_Value,
		@AccountCode_ValidFrom,
		@AccountCode_ValidTo,
		@IsAccountCode_Expirable,
		@AccountCode_CurrentStatus_RefID,
		@AccountCode_NumberOfAccesses_MaximumValue,
		@AccountCode_NumberOfAccesses_CurrentValue,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)