
    Select
      usr_accounts.Username,
      Case When (cmn_bpt_businessparticipants.IsNaturalPerson = 1) Then Concat_Ws(' ', cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName)
        When (cmn_bpt_businessparticipants.IsCompany = 1) Then cmn_bpt_businessparticipants.DisplayName End As name,
      usr_account_functionlevelrights.GlobalPropertyMatchingID As role,
      usr_accounts.AccountSignInEmailAddress As email,
      usr_accounts.AccountType,
      usr_accounts.USR_AccountID,
      usr_account_functionlevelrights_groups.GlobalPropertyMatchingID As group_id,
      cmn_per_personinfo.Title,
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
    From
      usr_accounts Inner Join
      cmn_bpt_businessparticipants
        On usr_accounts.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants.Tenant_RefID =
        @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
      cmn_per_personinfo
        On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0 And
        cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
      usr_account_2_functionlevelright
        On usr_account_2_functionlevelright.Account_RefID = usr_accounts.USR_AccountID And usr_account_2_functionlevelright.Tenant_RefID = @TenantID And
        usr_account_2_functionlevelright.IsDeleted = 0 Left Join
      usr_account_functionlevelrights
        On usr_account_functionlevelrights.USR_Account_FunctionLevelRightID = usr_account_2_functionlevelright.FunctionLevelRight_RefID And
        usr_account_functionlevelrights.IsDeleted = 0 And usr_account_functionlevelrights.Tenant_RefID = @TenantID Left Join
      usr_account_functionlevelrights_groups
        On usr_account_functionlevelrights_groups.USR_Account_FunctionLevelRights_GroupID = usr_account_functionlevelrights.FunctionLevelRights_Group_RefID And
        usr_account_functionlevelrights_groups.IsDeleted = 0 And usr_account_functionlevelrights_groups.Tenant_RefID = @TenantID
    Where
      usr_accounts.USR_AccountID = @AccountID And
      usr_accounts.Tenant_RefID = @TenantID And
      usr_accounts.IsDeleted = 0 
  