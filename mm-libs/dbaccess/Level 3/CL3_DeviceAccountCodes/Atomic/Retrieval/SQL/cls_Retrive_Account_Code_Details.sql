
	Select
		usr_device_accountcodes.Account_RefID,
		usr_device_accountcodes.USR_Device_AccountCodeID,
		usr_device_accountcodes.AccountCode_Value,
		usr_device_accountcodes.AccountCode_ValidFrom,
		usr_device_accountcodes.AccountCode_ValidTo,
		usr_device_accountcodes.IsAccountCode_Expirable,
		usr_device_accountcodes.AccountCode_CurrentStatus_RefID,
		usr_device_accountcodes.AccountCode_NumberOfAccesses_MaximumValue,
		usr_device_accountcodes.AccountCode_NumberOfAccesses_CurrentValue,
		usr_device_accountcodes.Tenant_RefID
	From
		usr_device_accountcodes Inner Join
		usr_device_accountcode_statushistory
			On usr_device_accountcodes.AccountCode_CurrentStatus_RefID =
			usr_device_accountcode_statushistory.USR_Device_AccountCode_StatusHistoryID
	Where
		usr_device_accountcode_statushistory.IsAccountCode_Active = 1 And
		usr_device_accountcodes.AccountCode_Value = @accounCodeValue And
		usr_device_accountcodes.IsDeleted = 0 And
		usr_device_accountcode_statushistory.IsDeleted = 0
	