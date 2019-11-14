UPDATE 
	cmn_tenant_applicationsettings_definitions
SET 
	ApplicationID=@ApplicationID,
	ItemKey=@ItemKey,
	DefaultValue=@DefaultValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_Tenant_ApplicationSettings_DefinitionsID = @CMN_Tenant_ApplicationSettings_DefinitionsID