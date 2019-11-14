
	Select
  usr_accounts.Username,
  FunctionLevelRights.USR_Account_FunctionLevelRightID,
  FunctionLevelRights.AssignmentID,
  FunctionLevelRights.RightName,
  usr_accounts.AccountType
From
  usr_accounts Inner Join
  cmn_account_applicationsubscriptions
    On cmn_account_applicationsubscriptions.Account_RefID =
    usr_accounts.USR_AccountID Left Join
  (Select
    usr_account_2_functionlevelright.Account_RefID,
    usr_account_functionlevelrights.RightName,
    usr_account_functionlevelrights.USR_Account_FunctionLevelRightID,
    usr_account_2_functionlevelright.AssignmentID
  From
    usr_account_2_functionlevelright Inner Join
    usr_account_functionlevelrights
      On usr_account_2_functionlevelright.FunctionLevelRight_RefID =
      usr_account_functionlevelrights.USR_Account_FunctionLevelRightID
  Where
    usr_account_2_functionlevelright.Tenant_RefID = @TenantID And
    usr_account_2_functionlevelright.IsDeleted = 0 And
    usr_account_functionlevelrights.IsDeleted = 0) FunctionLevelRights
    On usr_accounts.USR_AccountID = FunctionLevelRights.Account_RefID Inner Join
  tms_pro_projectmembers On tms_pro_projectmembers.USR_Account_RefID =
    usr_accounts.USR_AccountID
Where
  cmn_account_applicationsubscriptions.Application_RefID = @ApplicationID And
  cmn_account_applicationsubscriptions.IsDeleted = 0 And
  cmn_account_applicationsubscriptions.IsDisabled = 0 And
  usr_accounts.IsDeleted = 0 And
  usr_accounts.Tenant_RefID = @TenantID And
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID = @ProjectMemberID
  