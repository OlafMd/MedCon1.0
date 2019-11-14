
	Select
	  usr_account_functionlevelrights_groups.Label As GroupName,
	  usr_account_functionlevelrights_groups.USR_Account_FunctionLevelRights_GroupID,
	  usr_account_functionlevelrights.USR_Account_FunctionLevelRightID,
	  usr_account_functionlevelrights.RightName,
	  usr_account_functionlevelrights.GlobalPropertyMatchingID,
	  usr_account_functionlevelrights_groups.GlobalPropertyMatchingID As
	  Groups_GlobalPropertyMatchingID
	From
	  usr_account_functionlevelrights Right Join
	  usr_account_functionlevelrights_groups
	    On usr_account_functionlevelrights.FunctionLevelRights_Group_RefID =
	    usr_account_functionlevelrights_groups.USR_Account_FunctionLevelRights_GroupID And usr_account_functionlevelrights.IsDeleted = 0
	Where
	  usr_account_functionlevelrights_groups.IsDeleted = 0 And
	  usr_account_functionlevelrights_groups.Tenant_RefID = @TenantID
  