
	Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_patient_prescription_transactions.PrescriptionTransaction_InternalNubmer,
  hec_patient_prescription_transactions.Creation_Timestamp,
  hec_patients.IsPatientParticipationPolicyValidated,
  hec_patient_prescription_transactions.HEC_Patient_Prescription_TransactionID,
  hec_patient_prescription_transactions.PrescriptionTransaction_IsComplete,
  hec_patients_orderedby.CMN_BPT_BusinessParticipant_RefID,
  hec_patients.HEC_PatientID
From
  hec_patients Inner Join
  hec_patient_prescription_transactions
    On
    hec_patient_prescription_transactions.PrescriptionTransaction_Patient_RefID
    = hec_patients.HEC_PatientID Inner Join
  cmn_bpt_businessparticipants
    On
    hec_patient_prescription_transactions.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  hec_patients hec_patients_orderedby
    On hec_patients_orderedby.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  hec_patients.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_patient_prescription_transactions.IsDeleted = 0 And
  hec_patients.HEC_PatientID = @HEC_PatientID And
  hec_patients_orderedby.IsDeleted = 0
  