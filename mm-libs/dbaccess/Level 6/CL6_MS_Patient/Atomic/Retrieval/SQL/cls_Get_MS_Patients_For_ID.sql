
Select
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Salutation_General,
  hec_stu_study_participatingpatients.HasFulfilledParticipationPolicyRequirements,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  hec_patient_healthinsurances.HealthInsurance_Number,
  hec_patient_healthinsurances.HEC_Patient_HealthInsurancesID,
  hec_patients.PatientComment,
  hec_stu_study_participatingpatients.HEC_STU_Study_ParticipatingPatientID,
  Addresses.AssignmentID,
  Addresses.CMN_AddressID,
  Addresses.SequenceNumber,
  Addresses.IsPrimary,
  Addresses.Street_Name,
  Addresses.Street_Number,
  Addresses.City_Name,
  Addresses.City_PostalCode,
  Addresses.Province_Name,
  Contacts.Contact_Type,
  Contacts.Content,
  Contacts.CMN_PER_CommunicationContactID,
  hec_stu_study_participatingpatients.Participation_DateOfSigning,
  hec_stu_study_participatingpatients.Participation_Comment,
  usr_accounts.USR_AccountID,
  usr_device_accountcodes.AccountCode_Value,
  usr_device_accountcodes.USR_Device_AccountCodeID,
  hec_patients.HEC_PatientID
From
  cmn_per_personinfo Left Join
  (Select
    cmn_per_personinfo_2_address.AssignmentID,
    cmn_per_personinfo_2_address.CMN_PER_PersonInfo_RefID,
    cmn_per_personinfo_2_address.CMN_Address_RefID,
    cmn_addresses.CMN_AddressID,
    cmn_per_personinfo_2_address.SequenceNumber,
    cmn_per_personinfo_2_address.IsPrimary,
    cmn_addresses.Street_Name,
    cmn_addresses.Street_Number,
    cmn_addresses.City_Name,
    cmn_addresses.City_PostalCode,
    cmn_addresses.Province_Name
  From
    cmn_per_personinfo_2_address Inner Join
    cmn_addresses On cmn_per_personinfo_2_address.CMN_Address_RefID =
      cmn_addresses.CMN_AddressID
  Where
    cmn_addresses.IsDeleted = 0 And
    cmn_per_personinfo_2_address.IsDeleted = 0) Addresses
    On Addresses.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_patients On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  hec_stu_study_participatingpatients On hec_patients.HEC_PatientID =
    hec_stu_study_participatingpatients.Patient_RefID Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID Left Join
  (Select
    cmn_per_communicationcontacts.Content,
    cmn_per_communicationcontacts.Contact_Type,
    cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
    cmn_per_communicationcontacts.PersonInfo_RefID
  From
    cmn_per_communicationcontacts
  Where
    cmn_per_communicationcontacts.IsDeleted = 0) Contacts
    On Contacts.PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID
  Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  usr_device_accountcodes On usr_accounts.USR_AccountID =
    usr_device_accountcodes.Account_RefID
Where
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_patients.IsDeleted = 0 And
  hec_stu_study_participatingpatients.IsDeleted = 0 And
  hec_patient_healthinsurances.IsDeleted = 0 And
  usr_accounts.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  hec_patients.HEC_PatientID = @HEC_PatientID
Order By
  Addresses.SequenceNumber
	