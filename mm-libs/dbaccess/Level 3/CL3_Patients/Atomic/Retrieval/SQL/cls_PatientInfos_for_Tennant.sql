
Select
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.BirthDate,
  hec_patients.HEC_PatientID,
  hec_patients.CMN_BPT_BusinessParticipant_RefID,
  hec_patients.Creation_Timestamp,
  hec_patients.IsDeleted,
  hec_patients.Tenant_RefID,
  cmn_per_personinfo.Gender,
  cmn_per_personinfo.AgeCalculation_YearOfBirth,
  cmn_bpt_businessparticipants.DefaultLanguage_RefID,
  cmn_per_communicationcontacts.Contact_Type,
  cmn_per_communicationcontacts.Content,
  cmn_per_communicationcontacts.IsDefaultForContactType,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_bpt_businessparticipants.Modification_Timestamp As Modification_TimestampBP,
  hec_patients.Modification_Timestamp As Modification_TimestampPatient,
  cmn_per_personinfo.Modification_Timestamp As Modification_TimestampPersoInfo,
  cmn_per_communicationcontacts.Modification_Timestamp As  Modification_TimestampCommunicationContact,
  cmn_per_communicationcontact_types.Modification_Timestamp As  Modification_TimestampContactType
From
  cmn_bpt_businessparticipants Inner Join
  hec_patients On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID =
    cmn_per_communicationcontacts.Contact_Type
Where
  hec_patients.Tenant_RefID = @Tenant
Group By
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID,
  cmn_per_communicationcontact_types.Type,
  cmn_bpt_businessparticipants.IsDeleted, cmn_per_personinfo.IsDeleted,
  cmn_per_communicationcontacts.IsDeleted,
  cmn_bpt_businessparticipants.Modification_Timestamp,
  hec_patients.Modification_Timestamp,
  cmn_per_personinfo.Modification_Timestamp,
  cmn_per_communicationcontacts.Modification_Timestamp,
  cmn_per_communicationcontact_types.Modification_Timestamp
Having
  cmn_per_communicationcontact_types.Type = 'comunication-contact-type.mobile'
  