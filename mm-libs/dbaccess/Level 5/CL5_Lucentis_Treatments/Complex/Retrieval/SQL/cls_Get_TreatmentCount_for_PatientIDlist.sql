
 
Select
  hec_patients.HEC_PatientID,
  SUM(IFNULL(Query1.treatmentCount, 0))  As treatmentCount
From
  hec_patients Left Join
  (Select
    hec_patient_treatment.HEC_Patient_TreatmentID,
    hec_patient_2_patienttreatment.HEC_Patient_RefID,
    Count(*)As treatmentCount
  From
    hec_patient_2_patienttreatment Inner Join
    hec_patient_treatment
      On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
      hec_patient_treatment.HEC_Patient_TreatmentID
  Where
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_treatment.IsDeleted = 0 And
    hec_patient_treatment.IsTreatmentBilled = 1) Query1
    On Query1.HEC_Patient_RefID = hec_patients.HEC_PatientID
Where
  hec_patients.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID
Group By
  hec_patients.HEC_PatientID, Query1.treatmentCount
Having
  hec_patients.HEC_PatientID = @PatientID 

  