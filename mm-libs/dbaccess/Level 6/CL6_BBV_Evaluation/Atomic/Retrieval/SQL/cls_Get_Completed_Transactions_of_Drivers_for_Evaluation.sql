Select
  hec_patient_prescription_transactions.Creation_Timestamp,
  hec_patient_prescription_transactions.PrescriptionTransaction_IsComplete,
  Patient.FirstName As Patient_FristName,
  Patient.LastName As Patient_LastName,
  Prescriptions.PrescriptionCount,
  hec_patient_prescription_transactions.PrescriptionTransaction_CreatedByBusinessParticpant_RefID,
  hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID,
  Patient.HEC_PatientID
From
  hec_patient_prescription_transactions Inner Join
  (Select
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    hec_patients.HEC_PatientID
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
    hec_patients On hec_patients.CMN_BPT_BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    cmn_per_personinfo.IsDeleted = 0 And
    hec_patients.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID) Patient
    On
    hec_patient_prescription_transactions.PrescriptionTransaction_Patient_RefID
    = Patient.HEC_PatientID Left Join
  (Select
    hec_patient_prescription_2_prescriptiontransaction.HEC_Patient_Prescription_Transaction_RefID,
    Count(hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID) As
    PrescriptionCount
  From
    hec_patient_prescription_2_prescriptiontransaction Inner Join
    hec_patient_prescription_headers
      On
      hec_patient_prescription_2_prescriptiontransaction.HEC_Patient_Prescription_Header_RefID = hec_patient_prescription_headers.HEC_Patient_Prescription_HeaderID,
    hec_patients
  Where
    hec_patient_prescription_2_prescriptiontransaction.IsDeleted = 0 And
    hec_patient_prescription_headers.IsDeleted = 0 And
    hec_patient_prescription_2_prescriptiontransaction.Tenant_RefID = @TenantID
  Group By
    hec_patient_prescription_2_prescriptiontransaction.HEC_Patient_Prescription_Transaction_RefID) Prescriptions On Prescriptions.HEC_Patient_Prescription_Transaction_RefID = hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID
Where
  hec_patient_prescription_transactions.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = @BusinessParticipantID And
  hec_patient_prescription_transactions.IsDeleted = 0