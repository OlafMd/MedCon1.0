
	Select
  hec_patient_treatment.HEC_Patient_TreatmentID As TreatmentID,
  hec_patient_treatment.IfTreatmentPerformed_Date As TreatmentDate
From
  hec_patients Inner Join
  hec_patient_2_patienttreatment On hec_patients.HEC_PatientID =
    hec_patient_2_patienttreatment.HEC_Patient_RefID Inner Join
  hec_patient_treatment
    On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID
Where
  hec_patients.HEC_PatientID = @PatientID And
  hec_patients.Tenant_RefID = @TenantID And
  hec_patient_treatment.IsTreatmentPerformed = 1 And
  hec_patient_treatment.IsTreatmentFollowup = 0
  