INSERT INTO 
	usr_account_applicationsettings
	(
		USR_Account_ApplicationSettingID,
		Account_RefID,
		ApplicationSetting_Definition_RefID,
		ItemValue,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@USR_Account_ApplicationSettingID,
		@Account_RefID,
		@ApplicationSetting_Definition_RefID,
		@ItemValue,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)