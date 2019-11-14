
	Select
      DISTINCT cmn_account_applicationsubscriptions.Tenant_RefID
    From
      cmn_account_applicationsubscriptions
    Where
      cmn_account_applicationsubscriptions.Application_RefID = @ApplicationID
  