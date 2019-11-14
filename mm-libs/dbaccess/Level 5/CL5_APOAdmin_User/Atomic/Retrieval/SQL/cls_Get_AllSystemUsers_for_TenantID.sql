
Select
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  usr_accounts.USR_AccountID,
  usr_accounts.Username,
  usr_accounts.AccountSignInEmailAddress,
  usr_accounts.AccountType,
  usr_groups.Group_Name_DictID,
  usr_account_2_group.USR_Account_RefID,
  usr_groups.USR_GroupID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_PostalCode,
  cmn_addresses.City_Name,
  cmn_per_communicationcontacts.Content,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_per_communicationcontact_types.Type,
  cmn_per_communicationcontacts.IsDefaultForContactType
From
  cmn_bpt_businessparticipants Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_account_applicationsubscriptions
    On cmn_account_applicationsubscriptions.Account_RefID =
    usr_accounts.USR_AccountID Left Join
  usr_account_2_group On usr_accounts.USR_AccountID =
    usr_account_2_group.USR_Account_RefID Left Join
  usr_groups On usr_groups.USR_GroupID = usr_account_2_group.USR_Group_RefID
  Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_addresses On cmn_addresses.CMN_AddressID =
    cmn_per_personinfo.Address_RefID Inner Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontacts.Contact_Type =
    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID
Where
  usr_accounts.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  usr_accounts.Tenant_RefID = @TenantID And
  cmn_account_applicationsubscriptions.Application_RefID = @ApplicationID And
  cmn_account_applicationsubscriptions.IsDeleted = 0 And
  cmn_account_applicationsubscriptions.IsDisabled = 0
  