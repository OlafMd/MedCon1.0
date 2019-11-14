
Select
  hec_patient_findings.HEC_Patient_FindingID As finding_id,
  hec_patient_finding_documents.Document_RefID As file_url,
  hec_patient_finding_documents.Comment As file_name,
  hec_patient_findings.MedicalPractice_RefID As practice_id,
  hec_patient_findings.UndersigningDoctor_RefID As doctor_id,
  hec_patient_findings.Modification_Timestamp As modification_time,
  hec_patient_findings.Creation_Timestamp As date,
  hec_patient_findings.Patient_RefID,
  hec_patient_findings.MedicalPracticeType_RefID As referal_id
From
  hec_patient_findings Left Join
  hec_patient_finding_documents On hec_patient_findings.HEC_Patient_FindingID =
    hec_patient_finding_documents.Patient_Finding_RefID And
    hec_patient_finding_documents.IsDeleted = 0 And
    hec_patient_finding_documents.Tenant_RefID = @TenantID
Where
  hec_patient_findings.Patient_RefID = @PatientID And
  hec_patient_findings.Tenant_RefID = @TenantID And
  hec_patient_findings.IsDeleted = 0
  