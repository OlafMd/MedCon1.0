
Select
  doc_documentrevisions.File_Name,
  doc_documentrevisions.Revision

From
  doc_documentrevisions Inner Join
  doc_documents On doc_documents.IsDeleted = 0 And doc_documents.Tenant_RefID =
    @TenantID And doc_documentrevisions.Document_RefID
    = doc_documents.DOC_DocumentID
Where
  doc_documentrevisions.IsDeleted = 0 And
  doc_documentrevisions.Tenant_RefID = @TenantID

    