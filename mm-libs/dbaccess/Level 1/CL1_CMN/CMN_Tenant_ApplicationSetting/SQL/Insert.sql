INSERT INTO 
	cmn_tenant_applicationsettings
	(
		CMN_Tenant_ApplicationSettingsID,
		Tenant_RefID,
		ItemValue,
		ApplicationSettings_Definition_RefID,
		Creation_Timestamp,
		IsDeleted
	)
VALUES 
	(
		@CMN_Tenant_ApplicationSettingsID,
		@Tenant_RefID,
		@ItemValue,
		@ApplicationSettings_Definition_RefID,
		@Creation_Timestamp,
		@IsDeleted
	)