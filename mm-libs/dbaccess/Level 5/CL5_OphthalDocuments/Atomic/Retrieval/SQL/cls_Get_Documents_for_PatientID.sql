
	Select
    doc_documents.DOC_DocumentID,
    doc_documentrevisions.File_ServerLocation,
    doc_documentrevisions.File_Name,
    doc_documentrevisions.DOC_DocumentRevisionID,
    doc_documentrevisions.File_Size_Bytes,
    doc_documentrevisions.File_MIMEType,
    doc_documentrevisions.File_Extension,
    hec_patient_documents.HEC_Patient_DocumentID,
    hec_patient_documents.IsDocument_Standard,
    hec_patient_documents.IsDocument_PatientConsent,
    hec_patient_documents.IsDocument_PatientParticipationPolicy
  From
    doc_documents Inner Join
    doc_documentrevisions On doc_documents.DOC_DocumentID =
      doc_documentrevisions.Document_RefID Inner Join
    hec_patient_documents On hec_patient_documents.Document_RefID =
      doc_documents.DOC_DocumentID
  Where
    doc_documents.IsDeleted = 0 And
    doc_documentrevisions.IsDeleted = 0 And
    hec_patient_documents.IsDeleted = 0 And
    hec_patient_documents.Tenant_RefID = @TenantID And
    doc_documentrevisions.IsLastRevision = 1 And
    hec_patient_documents.Patient_RefID = @PatientID
  