UPDATE 
	cmn_tenant_applicationsettings
SET 
	Tenant_RefID=@Tenant_RefID,
	ItemValue=@ItemValue,
	ApplicationSettings_Definition_RefID=@ApplicationSettings_Definition_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	CMN_Tenant_ApplicationSettingsID = @CMN_Tenant_ApplicationSettingsID