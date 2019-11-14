
    Select
      Concat(cmn_per_personinfo.Title, ' ', cmn_per_personinfo.LastName, ' ',
      cmn_per_personinfo.FirstName) As user_name,
      usr_accounts.AccountSignInEmailAddress As user_login_email,
        usr_accounts.USR_AccountID as user_account_id
    From
      usr_accounts
      Inner Join usr_account_2_functionlevelright On usr_accounts.USR_AccountID =
        usr_account_2_functionlevelright.Account_RefID And
        usr_account_2_functionlevelright.IsDeleted = 0 And
        usr_account_2_functionlevelright.Tenant_RefID =
        @TenantID
      Inner Join usr_account_functionlevelrights
        On usr_account_2_functionlevelright.FunctionLevelRight_RefID =
        usr_account_functionlevelrights.USR_Account_FunctionLevelRightID And
        usr_account_functionlevelrights.Tenant_RefID =
        @TenantID And
        usr_account_functionlevelrights.IsDeleted = 0 And
        usr_account_functionlevelrights.GlobalPropertyMatchingID =
        @RightID
      Inner Join cmn_bpt_businessparticipants
        On usr_accounts.BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID =
        @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0
      Inner Join cmn_per_personinfo
        On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
        cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
        = @TenantID And cmn_per_personinfo.IsDeleted = 0
    Where
      usr_accounts.Tenant_RefID = @TenantID And
      usr_accounts.IsDeleted = 0        
    Order By
      Lower(Concat(cmn_per_personinfo.LastName, ' ', cmn_per_personinfo.FirstName))
  