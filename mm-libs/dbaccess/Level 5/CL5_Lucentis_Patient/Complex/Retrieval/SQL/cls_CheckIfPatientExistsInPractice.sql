
Select
  Count(hec_patient_healthinsurances.HealthInsurance_Number) as numberofID
From
  hec_patient_healthinsurances Inner Join
  hec_patients On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  hec_patient_medicalpractices On hec_patient_medicalpractices.HEC_Patient_RefID
    = hec_patients.HEC_PatientID And hec_patient_medicalpractices.IsDeleted = 0
    And hec_patient_medicalpractices.Tenant_RefID =
    @TenantID
Where
  hec_patient_healthinsurances.HealthInsurance_Number = @HealthInsuranceNumber And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patient_healthinsurances.Tenant_RefID =
  @TenantID And
  hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
  @PracticeID
  