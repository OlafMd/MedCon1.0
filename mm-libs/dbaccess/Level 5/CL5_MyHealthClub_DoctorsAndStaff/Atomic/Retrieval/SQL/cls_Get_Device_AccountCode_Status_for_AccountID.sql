
	Select
	  usr_device_accountcodes.USR_Device_AccountCodeID,
	  usr_device_accountcode_statushistory.IsAccountCode_Active,
	  usr_device_accountcode_statushistory.IsAccountCode_Revoked,
	  usr_device_accountcode_statushistory.IsAccountCode_Banned,
	  usr_device_accountcode_statushistory.IsAccountCode_Disabled,
	  usr_device_accountcode_statushistory.IsAccountCode_Expired
	From
	  usr_device_accountcodes Inner Join
	  usr_device_accountcode_statushistory
	    On usr_device_accountcodes.AccountCode_CurrentStatus_RefID =
	    usr_device_accountcode_statushistory.USR_Device_AccountCode_StatusHistoryID
	Where
	  usr_device_accountcodes.Account_RefID = @AccountRefID And
	  usr_device_accountcodes.IsDeleted = 0 And
	  usr_device_accountcodes.Tenant_RefID = @TenantID
  