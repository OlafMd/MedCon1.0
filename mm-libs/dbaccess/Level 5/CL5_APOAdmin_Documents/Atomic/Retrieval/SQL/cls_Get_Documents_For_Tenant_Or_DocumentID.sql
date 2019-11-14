
Select
  doc_documents.DOC_DocumentID,
  doc_documentrevisions.DOC_DocumentRevisionID,
  doc_documentrevisions.File_Name,
  doc_documentrevisions.File_SourceLocation,
  doc_documentrevisions.Creation_Timestamp,
  doc_documentrevisions.File_ServerLocation,
  usr_accounts.Username,
  ecm_doc_generaldocuments.ECM_DOC_GeneralDocumentID,
  ecm_doc_generaldocuments.IsPublicallyVisible
From
  doc_documents Inner Join
  doc_documentrevisions On doc_documents.DOC_DocumentID =
    doc_documentrevisions.Document_RefID Inner Join
  usr_accounts On doc_documentrevisions.UploadedByAccount =
    usr_accounts.USR_AccountID Inner Join
  ecm_doc_generaldocuments On doc_documents.DOC_DocumentID =
    ecm_doc_generaldocuments.Document_RefID
Where
  doc_documents.DOC_DocumentID = IfNull(@DOC_DocumentID,
  doc_documents.DOC_DocumentID) And
  doc_documents.Tenant_RefID = @TenantID And
  doc_documents.IsDeleted = 0
  