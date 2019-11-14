UPDATE 
	usr_device_accountcodes
SET 
	Account_RefID=@Account_RefID,
	AccountCode_Value=@AccountCode_Value,
	AccountCode_ValidFrom=@AccountCode_ValidFrom,
	AccountCode_ValidTo=@AccountCode_ValidTo,
	IsAccountCode_Expirable=@IsAccountCode_Expirable,
	AccountCode_CurrentStatus_RefID=@AccountCode_CurrentStatus_RefID,
	AccountCode_NumberOfAccesses_MaximumValue=@AccountCode_NumberOfAccesses_MaximumValue,
	AccountCode_NumberOfAccesses_CurrentValue=@AccountCode_NumberOfAccesses_CurrentValue,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_Device_AccountCodeID = @USR_Device_AccountCodeID