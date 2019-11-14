
	Select
  hec_patient_findings.HEC_Patient_FindingID As FindingID,
  hec_patient_findings.Patient_RefID As PatientID,
  hec_patient_findings.DateOfFindings,
  hec_patient_findings.MedicalPracticeType_RefID As PracticeTypeID,
  hec_patient_finding_documents.Document_RefID,
  hec_patient_finding_documents.Comment As Name,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  doc_documents.Alias As Size,
  doc_documents.PrimaryType As Type
From
  hec_patient_findings Inner Join
  hec_patient_finding_documents
    On hec_patient_finding_documents.Patient_Finding_RefID =
    hec_patient_findings.HEC_Patient_FindingID And
    hec_patient_finding_documents.IsDeleted = 0 And
    hec_patient_findings.IsDeleted = 0 And hec_patient_findings.Tenant_RefID =
    @TenantID And hec_patient_finding_documents.Tenant_RefID = @TenantID
  Inner Join
  hec_act_performedaction_patientprovidedfindings
    On hec_act_performedaction_patientprovidedfindings.HEC_Patient_Finding_RefID
    = hec_patient_findings.HEC_Patient_FindingID Inner Join
  hec_medicalpractice_types
    On hec_medicalpractice_types.HEC_MedicalPractice_TypeID =
    hec_patient_findings.MedicalPracticeType_RefID And
    hec_medicalpractice_types.Tenant_RefID = @TenantID And
    hec_medicalpractice_types.IsDeleted = 0 Inner Join
  doc_documents On doc_documents.DOC_DocumentID =
    hec_patient_finding_documents.Document_RefID
Where
  hec_act_performedaction_patientprovidedfindings.HEC_ACT_PerformedAction_RefID
  = @ExaminationID And
  hec_act_performedaction_patientprovidedfindings.Tenant_RefID = @TenantID And
  hec_act_performedaction_patientprovidedfindings.IsDeleted = 0
  