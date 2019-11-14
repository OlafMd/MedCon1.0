
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_communicationcontacts.Content,
  cmn_per_communicationcontact_types.Type,
  cmn_per_personinfo.PrimaryEmail,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_per_personinfo.Title,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.Country_ISOCode,
  hec_patients.HEC_PatientID As ID,
  cmn_per_personinfo.Gender,
  cmn_per_personinfo.BirthDate,
  cmn_addresses.City_PostalCode,
  cmn_per_personinfo_socialsecuritynumbers.SocialSecurityNumber,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_per_personinfo.ProfileImage_Document_RefID,
  cmn_per_personinfo.Salutation_General As AcademicTitle,
  cmn_languages.CMN_LanguageID,
  cmn_languages.Name_DictID,
  cmn_per_personinfo_socialsecuritynumbers.CMN_PER_PersonInfo_SocialSecurityNumberID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID And
    cmn_per_communicationcontacts.IsDeleted = 0 And
    cmn_per_communicationcontacts.Tenant_RefID = @TenantID Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID =
    cmn_per_communicationcontacts.Contact_Type And
    cmn_per_communicationcontact_types.IsDeleted = 0 And
    cmn_per_communicationcontact_types.Tenant_RefID = @TenantID Left Join
  cmn_addresses On cmn_per_personinfo.Address_RefID =
    cmn_addresses.CMN_AddressID  And
    (cmn_addresses.IsDeleted = 0 or cmn_addresses.IsDeleted is null) Inner Join
  hec_patients On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID And
    hec_patients.Tenant_RefID = @TenantID And hec_patients.IsDeleted = 0
  Left Join
  cmn_per_personinfo_socialsecuritynumbers
    On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_personinfo_socialsecuritynumbers.PersonInfo_RefID And
    (cmn_per_personinfo_socialsecuritynumbers.IsDeleted = 0 Or
      cmn_per_personinfo_socialsecuritynumbers.IsDeleted Is Null) Left Join
  cmn_bpt_businessparticipant_spokenlanguages
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_spokenlanguages.CMN_BPT_BusinessParticipant_RefID And cmn_bpt_businessparticipant_spokenlanguages.Tenant_RefID = @TenantID And cmn_bpt_businessparticipant_spokenlanguages.IsDeleted = 0 Left Join
  cmn_languages On cmn_languages.CMN_LanguageID =
    cmn_bpt_businessparticipant_spokenlanguages.CMN_Language_RefID And
    cmn_languages.IsDeleted = 0 And cmn_languages.Tenant_RefID = @TenantID
Where
  hec_patients.HEC_PatientID = @PatientID And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  