
	Select
	  cmn_tenant_applicationsettings_definitions.DefaultValue,
	  cmn_tenant_applicationsettings.ItemValue
	From
	  cmn_tenant_applicationsettings Right Join
	  cmn_tenant_applicationsettings_definitions
	    On
	    cmn_tenant_applicationsettings_definitions.CMN_Tenant_ApplicationSettings_DefinitionsID = cmn_tenant_applicationsettings.ApplicationSettings_Definition_RefID
	Where
	  cmn_tenant_applicationsettings_definitions.ItemKey = @TenantApplicationSettingsKey And
	  cmn_tenant_applicationsettings_definitions.Tenant_RefID = @TenantID And
	  cmn_tenant_applicationsettings.IsDeleted = 0 And
	  cmn_tenant_applicationsettings_definitions.IsDeleted = 0
  