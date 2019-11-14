
	Select
	  usr_accounts.USR_AccountID,
	  usr_accounts.Username,
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName,
	  cmn_per_personinfo.Title
	From
	  usr_accounts Inner Join
	  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
	    = usr_accounts.USR_AccountID Inner Join
	  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
	  cmn_account_applicationsubscriptions
	    On cmn_account_applicationsubscriptions.Account_RefID =
	    usr_accounts.USR_AccountID
	Where
	  usr_accounts.IsDeleted = 0 And
	  cmn_per_personinfo.IsDeleted = 0 And
	  cmn_per_personinfo_2_account.IsDeleted = 0 And
	  usr_accounts.Tenant_RefID = @TenantID And
	  cmn_account_applicationsubscriptions.IsDisabled = 0 And
	  cmn_account_applicationsubscriptions.IsDeleted = 0 And
	  cmn_account_applicationsubscriptions.Application_RefID = @ApplicationID
  