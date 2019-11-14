
	Select
	  cmn_tenant_applicationsubscriptions.CMN_Tenant_ApplicationSubscriptionID As TenantSubscriptionID,
	  cmn_tenant_applicationsubscriptions.Tenant_RefID,
	  cmn_tenant_applicationsubscriptions.Application_RefID
	From
	  cmn_tenant_applicationsubscriptions
	Where
	  cmn_tenant_applicationsubscriptions.Tenant_RefID = @TenantID And
	  cmn_tenant_applicationsubscriptions.Application_RefID = @ApplicationID And
	  cmn_tenant_applicationsubscriptions.IsDeleted = 0 And
	  cmn_tenant_applicationsubscriptions.IsDisabled = 0
  