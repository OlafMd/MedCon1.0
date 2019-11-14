
    Select
  hec_patient_healthinsurance_states.HEC_Patient_HealthInsurance_StateID,
  hec_patient_healthinsurance_states.HealthInsuranceState_Abbreviation,
  hec_patient_healthinsurance_states.HealthInsuranceState_Name_DictID
From
  hec_patient_healthinsurance_states
Where
  hec_patient_healthinsurance_states.IsDeleted = 0 And
  hec_patient_healthinsurance_states.Tenant_RefID = @TenantID
  