
Select
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Salutation_General,
  hec_stu_study_participatingpatients.HasFulfilledParticipationPolicyRequirements,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  hec_patients.HEC_PatientID,
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
  Policies.GlobalPropertyMatchingID,
  Policies.HEC_STU_Study_PatientDocumentID,
  hec_stu_study_participatingpatients.Participation_DateOfSigning,
  hec_stu_study_participatingpatients.Participation_Comment,
  Policies.File_Name,
  Policies.File_Extension,
  Policies.File_ServerLocation,
  Policies.File_Size_Bytes
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
  Left Join
  (Select
    doc_slt_documentslot.DOC_SLT_DocumentSlotID,
    doc_slt_documentslot.GlobalPropertyMatchingID,
    hec_stu_study_participationrequireddocuments.HEC_STU_Study_ParticipatingPatient_RequiredDocumentID,
    hec_stu_study_patientdocuments.ParticipatingPatient_RefID,
    hec_stu_study_patientdocuments.HEC_STU_Study_PatientDocumentID,
    doc_documentrevisions.File_Name,
    doc_documentrevisions.File_Extension,
    doc_documentrevisions.File_ServerLocation,
    doc_documentrevisions.File_Size_Bytes
  From
    doc_slt_documentslot Inner Join
    hec_stu_study_participationrequireddocuments
      On hec_stu_study_participationrequireddocuments.DOC_SLT_DocumentSlot_RefID
      = doc_slt_documentslot.DOC_SLT_DocumentSlotID Inner Join
    hec_stu_study_patientdocuments
      On hec_stu_study_patientdocuments.ParticipationRequiredDocument_RefID =
      hec_stu_study_participationrequireddocuments.HEC_STU_Study_ParticipatingPatient_RequiredDocumentID Inner Join
    doc_documents On hec_stu_study_patientdocuments.Document_RefID =
      doc_documents.DOC_DocumentID Inner Join
    doc_documentrevisions On doc_documentrevisions.Document_RefID =
      doc_documents.DOC_DocumentID
  Where
    doc_slt_documentslot.IsDeleted = 0 And
    hec_stu_study_participationrequireddocuments.IsDeleted = 0 And
    hec_stu_study_patientdocuments.IsDeleted = 0 And
    doc_documents.IsDeleted = 0 And
    doc_documentrevisions.IsDeleted = 0) Policies
    On hec_stu_study_participatingpatients.HEC_STU_Study_ParticipatingPatientID
    = Policies.ParticipatingPatient_RefID
Where
  hec_patients.HEC_PatientID = @HEC_PatientID And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_patients.IsDeleted = 0 And
  hec_stu_study_participatingpatients.IsDeleted = 0 And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID
Order By
  Addresses.SequenceNumber
	