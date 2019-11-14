
Select
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  info.CMN_PER_PersonInfoID,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID,
  user_acount.AccountCode_Value,
  info.FirstName,
  info.LastName,
  info.PrimaryEmail,
  info.Street_Name,
  info.Street_Number,
  info.City_PostalCode,
  info.Province_Name,
  info.Content,
  supplier.CMN_BPT_SupplierID,
  info.CMN_PER_CommunicationContact_TypeID,
  info.Salutation_General,
  info.City_Name,
  supplier.Contact_Email,
  supplier.CMN_UniversalContactDetailID,
  supplier.CMN_BPT_BusinessParticipantID As CMN_BPT_BusinessParticipantID1,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID,
  info.CMN_AddressID,
  info.CMN_PER_CommunicationContactID,
  user_acount.USR_AccountID,
  user_acount.USR_Device_AccountCode_UsageHistoryID,
  user_acount.USR_Device_AccountCodeID
From
  cmn_bpt_businessparticipants Left Join
  (Select
    usr_device_accountcodes.USR_Device_AccountCodeID,
    usr_device_accountcode_usagehistory.USR_Device_AccountCode_UsageHistoryID,
    usr_accounts.USR_AccountID,
    usr_device_accountcodes.AccountCode_Value,
    usr_device_accountcodes.AccountCode_ValidFrom,
    usr_accounts.BusinessParticipant_RefID
  From
    usr_accounts Inner Join
    usr_device_accountcodes On usr_device_accountcodes.Account_RefID =
      usr_accounts.USR_AccountID Inner Join
    usr_device_accountcode_usagehistory
      On usr_device_accountcode_usagehistory.Device_AccountCode_RefID =
      usr_device_accountcodes.USR_Device_AccountCodeID
  Where
    usr_device_accountcodes.IsDeleted = 0 And
    usr_device_accountcode_usagehistory.IsDeleted = 0 And
    usr_accounts.IsDeleted = 0 And
    usr_accounts.Tenant_RefID = @TenantID) user_acount
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    user_acount.BusinessParticipant_RefID Left Join
  (Select
    cmn_per_personinfo.CMN_PER_PersonInfoID,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    cmn_per_personinfo.PrimaryEmail,
    cmn_addresses.CMN_AddressID,
    cmn_addresses.Street_Name,
    cmn_addresses.Street_Number,
    cmn_addresses.City_PostalCode,
    cmn_addresses.Province_Name,
    cmn_per_communicationcontacts.Content,
    cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID,
    cmn_per_personinfo.Salutation_General,
    cmn_addresses.City_Name
  From
    cmn_per_personinfo Inner Join
    cmn_addresses On cmn_per_personinfo.Address_RefID =
      cmn_addresses.CMN_AddressID Inner Join
    cmn_per_personinfo_2_address
      On cmn_per_personinfo_2_address.CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID And
      cmn_per_personinfo_2_address.CMN_Address_RefID =
      cmn_addresses.CMN_AddressID Inner Join
    cmn_per_communicationcontacts
      On cmn_per_communicationcontacts.PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
    cmn_per_communicationcontact_types
      On cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID
      = cmn_per_communicationcontacts.Contact_Type
  Where
    cmn_per_communicationcontact_types.IsDeleted = 0 And
    cmn_per_communicationcontacts.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_per_personinfo_2_address.IsDeleted = 0 And
    cmn_addresses.IsDeleted = 0 And
    cmn_per_personinfo.Tenant_RefID = @TenantID) info
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    info.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  (Select
    cmn_bpt_suppliers.CMN_BPT_SupplierID,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
    cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID,
    cmn_universalcontactdetails.Contact_Email,
    cmn_universalcontactdetails.CMN_UniversalContactDetailID
  From
    cmn_bpt_suppliers Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Left Join
    cmn_com_companyinfo
      On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
    cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
      cmn_universalcontactdetails.CMN_UniversalContactDetailID
  Where
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_suppliers.IsDeleted = 0 And
    cmn_bpt_suppliers.Tenant_RefID = @TenantID) supplier
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = supplier.CMN_BPT_BusinessParticipantID
Where
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  