
Select
  hec_patient_prescription_transactions.PrescriptionTransaction_InternalNubmer,
  hec_patient_prescription_transactions.Creation_Timestamp,
  hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID,
  hec_patient_prescription_transactions.PrescriptionTransaction_IsComplete,
  hec_patient_prescription_transactions.PrescriptionTransaction_RequestedDateOfDeliveryFrom,
  hec_patient_prescription_transactions.PrescriptionTransaction_RequestedDateOfDeliveryTo,
  hec_patient_prescription_transactions.PrescriptionTransaction_CreatedByBusinessParticpant_RefID,
  hec_patient_prescription_transactions.PrescriptionTransaction_Comment,
  hec_patient_prescription_transactions.PrescriptionTransaction_Patient_RefID,
  hec_patient_prescription_transactions.PerscriptionTransaction_DeliveryAddress_RefID,
  hec_patient_prescription_transactions.PrescriptionTransaction_UsePatientAddress,
  hec_patient_prescription_transactions.PrescriptionTransaction_UseReceiptAddress,
  hec_patient_prescription_transactions.PrescriptionTransaction_UseParticipationPolicyAddress,
  Driver.FirstName As Driver_FirstName,
  Driver.LastName As Driver_LastName,
  Driver.CompanyName_Line1 As Driver_CompanyName,
  Patient.FirstName As Patient_FristName,
  Patient.LastName As Patient_LastName,
  Patient.HealthInsurance_Number As Patient_InsuranceNumber,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Province_Name,
  cmn_addresses.City_Name,
  Prescriptions.HEC_Patient_Prescription_HeaderID,
  Prescriptions.DOC_DocumentRevisionID,
  Prescriptions.File_ServerLocation,
  Patient.Salutation_General
From
  hec_patient_prescription_transactions Left Join
  (Select
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    cmn_universalcontactdetails.CompanyName_Line1,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  From
    cmn_bpt_businessparticipants Inner Join
    cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    Inner Join
    cmn_bpt_businessparticipant_associatedbusinessparticipants
      On
      cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    cmn_bpt_businessparticipants cmn_bpt_businessparticipants_company
      On
      cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants_company.CMN_BPT_BusinessParticipantID Inner Join
    cmn_com_companyinfo
      On
      cmn_bpt_businessparticipants_company.IfCompany_CMN_COM_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
    cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
      cmn_universalcontactdetails.CMN_UniversalContactDetailID
  Where
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_bpt_businessparticipants_company.IsDeleted = 0 And
    cmn_com_companyinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
    cmn_per_personinfo.Tenant_RefID = @TenantID) Driver
    On
    hec_patient_prescription_transactions.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = Driver.CMN_BPT_BusinessParticipantID Left Join
  (Select
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    hec_patient_healthinsurances.HealthInsurance_Number,
    hec_patients.HEC_PatientID,
    cmn_per_personinfo.Salutation_General
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
    hec_patients On hec_patients.CMN_BPT_BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    hec_stu_study_participatingpatients On hec_patients.HEC_PatientID =
      hec_stu_study_participatingpatients.Patient_RefID Left Join
    hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
      hec_patients.HEC_PatientID
  Where
    hec_stu_study_participatingpatients.HasFulfilledParticipationPolicyRequirements = 1 And
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    hec_patients.IsDeleted = 0 And
    hec_stu_study_participatingpatients.IsDeleted = 0 And
    hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID And
    hec_patient_healthinsurances.IsPrimary = 1) Patient
    On
    hec_patient_prescription_transactions.PrescriptionTransaction_Patient_RefID
    = Patient.HEC_PatientID Left Join
  (Select
    hec_patient_prescription_2_prescriptiontransaction.HEC_Patient_Prescription_Transaction_RefID,
    doc_documentrevisions.File_ServerLocation,
    doc_documentrevisions.DOC_DocumentRevisionID,
    hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID
  From
    hec_patient_prescription_2_prescriptiontransaction Inner Join
    hec_patient_prescription_headers
      On
      hec_patient_prescription_2_prescriptiontransaction.HEC_Patient_Prescription_Header_RefID = hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID Inner Join
    hec_patient_prescription_documents
      On hec_patient_prescription_documents.PrescriptionHeader_RefID =
      hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID
    Inner Join
    doc_documents On hec_patient_prescription_documents.Document_RefID =
      doc_documents.DOC_DocumentID Inner Join
    doc_documentrevisions On doc_documentrevisions.Document_RefID =
      doc_documents.DOC_DocumentID
  Where
    hec_patient_prescription_2_prescriptiontransaction.IsDeleted = 0 And
    hec_patient_prescription_headers.IsDeleted = 0 And
    hec_patient_prescription_documents.IsDeleted = 0 And
    hec_patient_prescription_2_prescriptiontransaction.Tenant_RefID = @TenantID
    And
    doc_documents.IsDeleted = 0 And
    doc_documentrevisions.IsLastRevision = 1) Prescriptions
    On Prescriptions.HEC_Patient_Prescription_Transaction_RefID =
    hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID
  Left Join
  cmn_addresses
    On
    hec_patient_prescription_transactions.PerscriptionTransaction_DeliveryAddress_RefID = cmn_addresses.CMN_AddressID
Where
  hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID =
  @TransactionID And
  hec_patient_prescription_transactions.IsDeleted = 0 And
  hec_patient_prescription_transactions.Tenant_RefID = @TenantID
  