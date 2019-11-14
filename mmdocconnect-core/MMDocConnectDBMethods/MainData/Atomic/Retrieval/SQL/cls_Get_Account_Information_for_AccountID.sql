
Select
  Concat(cmn_per_personinfo.LastName, ', ', cmn_per_personinfo.FirstName) As
  UserName,
  usr_account_functionlevelrights.RightName As Rights,
  usr_accounts.AccountSignInEmailAddress As LoginMail,
  cmn_per_communicationcontacts.Content,
  cmn_per_communicationcontact_types.Type,
  cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID,
  usr_accounts.IsDeactivated,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General As Salutation,
  usr_accounts.USR_AccountID As AccountID,
  usr_account_applicationsettings.ItemValue As ReceiveNotification
From
  usr_accounts Inner Join
  usr_account_2_functionlevelright
    On usr_account_2_functionlevelright.Account_RefID =
    usr_accounts.USR_AccountID And usr_account_2_functionlevelright.Tenant_RefID
    = @TenantID And
    usr_account_2_functionlevelright.IsDeleted = 0 Inner Join
  usr_account_functionlevelrights
    On usr_account_2_functionlevelright.FunctionLevelRight_RefID =
    usr_account_functionlevelrights.USR_Account_FunctionLevelRightID And
    usr_account_functionlevelrights.Tenant_RefID =
    @TenantID And
    usr_account_functionlevelrights.IsDeleted = 0 And
    (usr_account_functionlevelrights.GlobalPropertyMatchingID =
      'mm.docconect.mm.app.regular' Or
      usr_account_functionlevelrights.GlobalPropertyMatchingID =
      'mm.docconect.mm.app.master') Inner Join
  cmn_bpt_businessparticipants On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID =
    @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
    = @TenantID And cmn_per_personinfo.IsDeleted = 0
  Left Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID And
    cmn_per_communicationcontacts.Tenant_RefID =
    @TenantID And
    cmn_per_communicationcontacts.IsDeleted = 0 And
    cmn_per_communicationcontacts.Tenant_RefID =
    @TenantID And
    cmn_per_communicationcontacts.IsDeleted = 0 Left Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontacts.Contact_Type =
    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID And
    cmn_per_communicationcontact_types.Tenant_RefID =
    @TenantID And
    cmn_per_communicationcontact_types.IsDeleted = 0 Left Join
  usr_account_applicationsettings
    On usr_account_applicationsettings.Account_RefID =
    usr_accounts.USR_AccountID And usr_account_applicationsettings.IsDeleted = 0
    And usr_account_applicationsettings.Tenant_RefID =
    @TenantID
Where
  usr_accounts.Tenant_RefID = @TenantID And
  usr_accounts.IsDeleted = 0 And
  usr_accounts.USR_AccountID = @UserAccountID
Order By
  Lower(usr_accounts.Username)
  