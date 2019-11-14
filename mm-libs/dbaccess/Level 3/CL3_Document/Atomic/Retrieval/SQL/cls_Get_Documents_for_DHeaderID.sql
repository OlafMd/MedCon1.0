
Select
  doc_documents.DOC_DocumentID,
  doc_documents.Alias,
  doc_document_2_structure.AssignmentID,
  doc_document_2_structure.Structure_RefID,
  doc_documentrevisions.Revision,
  doc_documentrevisions.File_ServerLocation,
  doc_documentrevisions.File_Name,
  doc_documentrevisions.DOC_DocumentRevisionID,
  doc_documentrevisions.IsLastRevision,
  doc_document_2_structure.StructureHeader_RefID,
  doc_documentrevisions.IsLocked,
  doc_documentrevisions.File_Description,
  doc_documentrevisions.File_SourceLocation,
  doc_documentrevisions.File_Size_Bytes,
  doc_documentrevisions.File_MIMEType,
  doc_documentrevisions.File_Extension,
  doc_documents.PrimaryType,
  doc_documentrevisions.Document_RefID,
  doc_documentrevisions.Creation_Timestamp
From
  doc_documents Inner Join
  doc_document_2_structure On doc_document_2_structure.Document_RefID =
    doc_documents.DOC_DocumentID Left Join
  doc_documentrevisions On doc_documents.DOC_DocumentID =
    doc_documentrevisions.Document_RefID
Where
  doc_document_2_structure.StructureHeader_RefID = @DHeaderID And
  doc_document_2_structure.IsDeleted = 0 And
  doc_documents.IsDeleted = 0 And
  doc_documentrevisions.IsDeleted = 0
Order By
  doc_documents.Alias,
  doc_document_2_structure.Structure_RefID
  