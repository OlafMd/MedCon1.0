
	Select
	  usr_accounts.BusinessParticipant_RefID,
	  usr_accounts.Tenant_RefID,
	  usr_accounts.IsDeleted,
	  usr_accounts.Username,
	  usr_accounts.DefaultLanguage_RefID,
	  usr_accounts.USR_AccountID,
	  usr_accounts.AccountType
	From
	  usr_accounts
	Where
	  usr_accounts.Tenant_RefID = @TenantID and usr_accounts.IsDeleted = 0 and usr_accounts.AccountType = 0
  