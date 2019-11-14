
Select
  hec_patient_finding_documents.HEC_Patient_Finding_DocumentID As id,
  hec_patient_finding_documents.Comment As name,
  hec_patient_finding_documents.Document_RefID,
  doc_documents.PrimaryType As mime_type,
  doc_documents.Alias As size
From
  hec_patient_finding_documents Inner Join
  doc_documents On doc_documents.DOC_DocumentID =
    hec_patient_finding_documents.Document_RefID And doc_documents.IsDeleted = 0
    And doc_documents.Tenant_RefID = @TenantID
Where
  hec_patient_finding_documents.Patient_Finding_RefID = @FindingID And
  hec_patient_finding_documents.Tenant_RefID = @TenantID And
  hec_patient_finding_documents.IsDeleted = 0
  