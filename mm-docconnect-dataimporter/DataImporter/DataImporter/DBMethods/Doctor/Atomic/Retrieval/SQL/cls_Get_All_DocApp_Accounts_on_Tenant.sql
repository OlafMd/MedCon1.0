
    Select
      usr_accounts.USR_AccountID as account_id,      
      usr_accounts.AccountSignInEmailAddress as email
    From
      usr_accounts Inner Join
      usr_account_2_functionlevelright
        On usr_accounts.USR_AccountID = usr_account_2_functionlevelright.Account_RefID And
        usr_account_2_functionlevelright.Tenant_RefID = @TenantID And
        usr_account_2_functionlevelright.IsDeleted = 0 Inner Join
      usr_account_functionlevelrights
        On usr_account_2_functionlevelright.FunctionLevelRight_RefID = usr_account_functionlevelrights.USR_Account_FunctionLevelRightID And    
  	    usr_account_functionlevelrights.GlobalPropertyMatchingID Like 'mm.docconect.doc.app%' And
  	    usr_account_functionlevelrights.Tenant_RefID = @TenantID And
  	    usr_account_functionlevelrights.IsDeleted = 0
    Where
      usr_accounts.Tenant_RefID = @TenantID And
      usr_accounts.IsDeleted = 0
	