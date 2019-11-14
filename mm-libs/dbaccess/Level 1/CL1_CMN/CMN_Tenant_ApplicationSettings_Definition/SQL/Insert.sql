INSERT INTO 
	cmn_tenant_applicationsettings_definitions
	(
		CMN_Tenant_ApplicationSettings_DefinitionsID,
		ApplicationID,
		ItemKey,
		DefaultValue,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_Tenant_ApplicationSettings_DefinitionsID,
		@ApplicationID,
		@ItemKey,
		@DefaultValue,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)