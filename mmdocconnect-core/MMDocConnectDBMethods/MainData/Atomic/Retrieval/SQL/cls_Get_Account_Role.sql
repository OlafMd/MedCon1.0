
    Select
      usr_account_functionlevelrights.GlobalPropertyMatchingID As role,
      usr_account_functionlevelrights_groups.GlobalPropertyMatchingID As group_id
    From
      usr_account_2_functionlevelright Inner Join
      usr_account_functionlevelrights
        On usr_account_2_functionlevelright.FunctionLevelRight_RefID = usr_account_functionlevelrights.USR_Account_FunctionLevelRightID And
        usr_account_functionlevelrights.Tenant_RefID = @TenantID And usr_account_functionlevelrights.IsDeleted = 0 Inner Join
      usr_account_functionlevelrights_groups
        On usr_account_functionlevelrights.FunctionLevelRights_Group_RefID = usr_account_functionlevelrights_groups.USR_Account_FunctionLevelRights_GroupID And
        usr_account_functionlevelrights_groups.Tenant_RefID = @TenantID And usr_account_functionlevelrights_groups.IsDeleted = 0
    Where
      usr_account_2_functionlevelright.Account_RefID = @AccountID And
      usr_account_2_functionlevelright.Tenant_RefID = @TenantID And
      usr_account_2_functionlevelright.IsDeleted = 0
    Limit 1
  