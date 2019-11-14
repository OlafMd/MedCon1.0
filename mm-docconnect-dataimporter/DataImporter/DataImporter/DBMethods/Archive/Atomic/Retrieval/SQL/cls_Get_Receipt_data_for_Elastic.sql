
Select
  doc_documents.Alias as recipient,
  doc_documents.PrimaryType as file_type,
  doc_documentrevisions.File_Description as description,
  doc_documents.Creation_Timestamp as file_date,
  doc_documentrevisions.File_ServerLocation As document_id,
  doc_documents.DOC_DocumentID as id
From
  doc_documents Inner Join
  doc_document_2_structure On doc_documents.DOC_DocumentID =
    doc_document_2_structure.Document_RefID And doc_documents.IsDeleted = 0 And
    doc_documents.Tenant_RefID = @TenantID Inner Join
  doc_structures On doc_document_2_structure.Structure_RefID =
    doc_structures.DOC_StructureID And doc_structures.IsDeleted = 0 And
    doc_structures.Tenant_RefID = @TenantID Inner Join
  doc_documentrevisions On doc_documentrevisions.Document_RefID =
    doc_documents.DOC_DocumentID And doc_documentrevisions.IsDeleted = 0 And
    doc_documentrevisions.Tenant_RefID = @TenantID
    Where
  doc_documents.GlobalPropertyMatchingID = "pdf doc" And
  doc_documents.Tenant_RefID = @TenantID And
  doc_documents.IsDeleted = 0
  