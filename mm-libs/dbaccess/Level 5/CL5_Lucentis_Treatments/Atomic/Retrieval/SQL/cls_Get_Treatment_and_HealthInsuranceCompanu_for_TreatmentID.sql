
Select
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID,
  hec_patient_treatment.Tenant_RefID,
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber
From
  hec_patient_treatment Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID Inner Join
  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID Inner Join
  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
    hec_patient_healthinsurances.Patient_RefID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID
Where
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentID And
  hec_patient_treatment.Tenant_RefID = @TenantID
  