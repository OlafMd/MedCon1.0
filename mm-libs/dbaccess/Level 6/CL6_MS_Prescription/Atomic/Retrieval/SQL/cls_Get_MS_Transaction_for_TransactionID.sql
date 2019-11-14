
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
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Province_Name,
  cmn_addresses.City_Name,
  Prescriptions.HEC_Patient_Prescription_HeaderID,
  Prescriptions.DOC_DocumentRevisionID,
  Prescriptions.File_ServerLocation,
  cmn_per_personinfo.FirstName As Patient_FristName,
  cmn_per_personinfo.LastName As Patient_LastName,
  hec_patient_healthinsurances.HealthInsurance_Number As
  Patient_InsuranceNumber,
  cmn_per_personinfo.Salutation_General
From
  hec_patient_prescription_transactions Left Join
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
    hec_patient_prescription_transactions.PerscriptionTransaction_DeliveryAddress_RefID = cmn_addresses.CMN_AddressID Inner Join
  hec_patients
    On
    hec_patient_prescription_transactions.PrescriptionTransaction_Patient_RefID
    = hec_patients.HEC_PatientID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patient_healthinsurances.Patient_RefID = hec_patients.HEC_PatientID
Where
  hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID =
  @TransactionID And
  hec_patient_prescription_transactions.IsDeleted = 0 And
  hec_patient_prescription_transactions.Tenant_RefID = @TenantID And
  hec_patients.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0
  