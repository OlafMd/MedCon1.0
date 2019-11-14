
	Select
	  usr_accounts.USR_AccountID,
	  usr_accounts.DefaultLanguage_RefID,
	  usr_accounts.Username,
	  usr_accounts.BusinessParticipant_RefID,
	  usr_accounts.AccountSignInEmailAddress,
	  usr_accounts.AccountType,
	  usr_accounts.RemoveViewedNotificationAfterDays
	From
	  usr_accounts
	Where
	  usr_accounts.IsDeleted = 0 And
	  usr_accounts.Tenant_RefID = @TenantID And
	  UPPER(usr_accounts.AccountSignInEmailAddress) = UPPER(@SignInEmail)
  