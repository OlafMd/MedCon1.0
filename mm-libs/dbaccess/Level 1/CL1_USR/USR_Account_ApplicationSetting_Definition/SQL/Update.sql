UPDATE 
	usr_account_applicationsetting_definitions
SET 
	ItemKey=@ItemKey,
	DefaultValue=@DefaultValue,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_Account_ApplicationSetting_DefinitionID = @USR_Account_ApplicationSetting_DefinitionID