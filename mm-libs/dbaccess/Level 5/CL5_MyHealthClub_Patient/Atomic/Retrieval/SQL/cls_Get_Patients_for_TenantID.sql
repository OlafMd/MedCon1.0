
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_communicationcontacts.Content,
  cmn_per_personinfo.PrimaryEmail,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_per_personinfo.Title,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.Country_ISOCode,
  hec_patients.HEC_PatientID As ID,
  cmn_bpt_businessparticipants1.DisplayName As HICompanyName,
  cmn_per_personinfo.BirthDate,
  cmn_per_communicationcontact_types.Type,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID And
    (cmn_per_communicationcontacts.IsDeleted = 0 Or
      cmn_per_communicationcontacts.IsDeleted Is Null) Left Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID =
    cmn_per_communicationcontacts.Contact_Type And
    (cmn_per_communicationcontact_types.IsDeleted = 0 Or
      cmn_per_communicationcontact_types.IsDeleted Is Null) Left Join
  cmn_addresses On cmn_per_personinfo.Address_RefID =
    cmn_addresses.CMN_AddressID And cmn_addresses.Tenant_RefID = @TenantID And
    (cmn_addresses.IsDeleted = 0 Or cmn_addresses.IsDeleted Is Null) Inner Join
  hec_patients On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID And
    hec_patients.Tenant_RefID = @TenantID And hec_patients.IsDeleted = 0
  Left Join
  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
    hec_patient_healthinsurances.Patient_RefID And
    hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID Left Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants1.IsCompany = 1 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID
Where
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  