
	Select
	  usr_accounts.AccountSignInEmailAddress
	From
	  usr_account_2_functionlevelright Inner Join
	  usr_account_functionlevelrights
	    On usr_account_functionlevelrights.USR_Account_FunctionLevelRightID =
	    usr_account_2_functionlevelright.FunctionLevelRight_RefID Inner Join
	  usr_accounts
	    On usr_accounts.USR_AccountID =
	    usr_account_2_functionlevelright.Account_RefID
	Where
	  usr_account_functionlevelrights.RightName = "CompanyTimeTracking" And
	  usr_account_functionlevelrights.Tenant_RefID = @TenantID
  