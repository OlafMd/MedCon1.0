
		SELECT
		  usr_accounts.USR_AccountID,
      usr_account_functionlevelrights.USR_Account_FunctionLevelRightID,
		  usr_account_functionlevelrights.GlobalPropertyMatchingID as RightLevel
		FROM
		  usr_accounts
		  INNER JOIN usr_account_2_functionlevelright
		    ON usr_accounts.USR_AccountID = usr_account_2_functionlevelright.Account_RefID
		    AND usr_account_2_functionlevelright.IsDeleted = 0
		  INNER JOIN usr_account_functionlevelrights
		    ON usr_account_2_functionlevelright.FunctionLevelRight_RefID = usr_account_functionlevelrights.USR_Account_FunctionLevelRightID
		    AND usr_account_functionlevelrights.IsDeleted = 0
		  INNER JOIN usr_account_functionlevelrights_groups
		    ON usr_account_functionlevelrights.FunctionLevelRights_Group_RefID = usr_account_functionlevelrights_groups.USR_Account_FunctionLevelRights_GroupID
		    AND usr_account_functionlevelrights_groups.IsDeleted = 0
		WHERE
		  usr_accounts.IsDeleted = 0
		  AND usr_accounts.USR_AccountID = @AccountID
		  AND usr_account_functionlevelrights_groups.GlobalPropertyMatchingID = @AccountFunctionLevelRightGroup
		  AND usr_accounts.Tenant_RefID = @TenantID
		ORDER BY usr_account_functionlevelrights.Creation_Timestamp DESC

  