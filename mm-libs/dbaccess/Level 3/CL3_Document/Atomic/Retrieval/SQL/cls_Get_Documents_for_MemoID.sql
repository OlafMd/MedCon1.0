
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
      doc_document_2_structure On doc_documents.DOC_DocumentID =
      doc_document_2_structure.Document_RefID Left Join
      doc_documentrevisions On doc_documents.DOC_DocumentID =
      doc_documentrevisions.Document_RefID Inner Join
      doc_structure_headers On doc_document_2_structure.StructureHeader_RefID =
      doc_structure_headers.DOC_Structure_HeaderID Inner Join
      cmn_bpt_memos On cmn_bpt_memos.DOC_Structure_Header_RefID =
      doc_structure_headers.DOC_Structure_HeaderID
    Where
      doc_documents.IsDeleted = 0 And
      doc_document_2_structure.IsDeleted = 0 And
      doc_structure_headers.IsDeleted = 0 And
      cmn_bpt_memos.IsDeleted = 0 And
      cmn_bpt_memos.Tenant_RefID = @TenantID And
      cmn_bpt_memos.CMN_BPT_MemoID = @ID And
      (doc_documentrevisions.IsDeleted Is Null Or
        doc_documentrevisions.IsDeleted = 0)
    Order By
      doc_documents.Alias,
      doc_document_2_structure.Structure_RefID  
  