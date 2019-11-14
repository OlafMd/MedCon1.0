
    Select
      hec_patient_healthinsurances.Patient_RefID as patient_id
    From
      hec_patient_healthinsurances Inner Join
      hec_patient_medicalpractices On hec_patient_healthinsurances.Patient_RefID =
        hec_patient_medicalpractices.HEC_Patient_RefID And
        hec_patient_medicalpractices.Tenant_RefID = @TenantID And
        hec_patient_medicalpractices.IsDeleted = 0 And
       hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @PracticeID
    Where
      hec_patient_healthinsurances.HealthInsurance_Number = @HIP And
      hec_patient_healthinsurances.Tenant_RefID = @TenantID And
      hec_patient_healthinsurances.IsDeleted = 0
  