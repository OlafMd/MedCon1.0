
	SELECT
	  usr_accounts.USR_AccountID,
    usr_account_functionlevelrights.USR_Account_FunctionLevelRightID,
	  usr_account_functionlevelrights.GlobalPropertyMatchingID as RightLevel
	FROM
	  usr_accounts
	  INNER JOIN usr_account_2_group
	    ON usr_accounts.USR_AccountID = usr_account_2_group.USR_Account_RefID
	    AND usr_account_2_group.IsDeleted = 0
	  INNER JOIN usr_groups
	    ON usr_account_2_group.USR_Group_RefID = usr_groups.USR_GroupID
	    AND usr_groups.IsDeleted = 0
	  INNER JOIN usr_groups_2_functionlevelright
	    ON usr_groups.USR_GroupID = usr_groups_2_functionlevelright.USR_Group_RefID
	    AND usr_groups_2_functionlevelright.IsDeleted = 0
	  INNER JOIN usr_account_functionlevelrights
	    ON usr_groups_2_functionlevelright.USR_Account_FunctionLevelRight_RefID = usr_account_functionlevelrights.USR_Account_FunctionLevelRightID
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
  