
    Select
      doc_documents.Alias As ActionID,
      doc_documentrevisions.File_ServerLocation As DocumentID,
      doc_documentrevisions.File_Name As DocumentName
    From
      doc_documents
      Inner Join doc_documentrevisions
        On doc_documents.DOC_DocumentID = doc_documentrevisions.Document_RefID And doc_documentrevisions.Tenant_RefID = @TenantID And doc_documentrevisions.IsDeleted = 0 And
        doc_documentrevisions.IsLastRevision = 1
    Where
      doc_documents.IsDeleted = 0 And
      doc_documents.Tenant_RefID = @TenantID
    