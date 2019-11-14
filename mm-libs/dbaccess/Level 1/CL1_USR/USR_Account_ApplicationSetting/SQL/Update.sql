UPDATE 
	usr_account_applicationsettings
SET 
	Account_RefID=@Account_RefID,
	ApplicationSetting_Definition_RefID=@ApplicationSetting_Definition_RefID,
	ItemValue=@ItemValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	USR_Account_ApplicationSettingID = @USR_Account_ApplicationSettingID