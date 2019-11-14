
 Select
  doc_documentrevisions.File_ServerLocation As DocumentID
From
  doc_structures Inner Join
  doc_document_2_structure
    On doc_structures.DOC_StructureID = doc_document_2_structure.Structure_RefID
    And doc_document_2_structure.IsDeleted = 0 And
    doc_document_2_structure.Tenant_RefID = @TenantID Inner Join
  doc_documents
    On doc_document_2_structure.Document_RefID = doc_documents.DOC_DocumentID
    And doc_documents.IsDeleted = 0 And doc_documents.Tenant_RefID = @TenantID
    And doc_documents.GlobalPropertyMatchingID = 'Submitted order pdf'
  Inner Join
  doc_documentrevisions
    On doc_documents.DOC_DocumentID = doc_documentrevisions.Document_RefID And
    doc_documentrevisions.IsLastRevision = 1 And doc_documentrevisions.IsDeleted
    = 0 And doc_documentrevisions.Tenant_RefID = @TenantID
Where
  doc_structures.Label = @OrderID And
  doc_structures.IsDeleted = 0 And
  doc_structures.Tenant_RefID = @TenantID
  