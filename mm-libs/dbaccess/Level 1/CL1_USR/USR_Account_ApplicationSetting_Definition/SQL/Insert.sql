INSERT INTO 
	usr_account_applicationsetting_definitions
	(
		USR_Account_ApplicationSetting_DefinitionID,
		ApplicationID,
		ItemKey,
		DefaultValue,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@USR_Account_ApplicationSetting_DefinitionID,
		@ApplicationID,
		@ItemKey,
		@DefaultValue,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)