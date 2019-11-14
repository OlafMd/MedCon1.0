
	Select
  cmn_account_applicationsubscriptions.Application_RefID
From
  usr_accounts Inner Join
  cmn_account_applicationsubscriptions
    On cmn_account_applicationsubscriptions.Account_RefID =
    usr_accounts.USR_AccountID
Where
  usr_accounts.USR_AccountID = @AcountID And
  usr_accounts.IsDeleted = 0 And
  cmn_account_applicationsubscriptions.IsDeleted = 0 And
  usr_accounts.Tenant_RefID = @TenantID
  