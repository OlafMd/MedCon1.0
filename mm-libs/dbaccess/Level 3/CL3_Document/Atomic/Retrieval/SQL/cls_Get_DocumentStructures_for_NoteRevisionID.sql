
  Select
    doc_structures.DOC_StructureID,
    doc_structures.Label,
    doc_structures.Parent_RefID,
    doc_structures.Structure_Header_RefID
  From
    doc_structures 
  Inner Join
    doc_document_2_structure 
  On 
    doc_document_2_structure.Structure_RefID = doc_structures.DOC_StructureID 
  And
    doc_document_2_structure.isDeleted = 0
  Inner Join
    doc_documents       
  On  
    doc_documents.DOC_DocumentID = doc_document_2_structure.Document_RefID  
  Inner Join
    cmn_noterevision_attachments
  On
    cmn_noterevision_attachments.Document_RefID = doc_documents.DOC_DocumentID    
  And
    cmn_noterevision_attachments.IsDeleted
  Inner Join
    cmn_noterevisions
  On
    cmn_noterevisions.CMN_NoteRevisionID= cmn_noterevision_attachments.NoteRevision_RefID
  Where
    doc_structures.IsDeleted = 0 And
    cmn_noterevisions.IsDeleted = 0 And
    cmn_noterevisions.Tenant_RefID = @TenantID And
    cmn_noterevisions.CMN_NoteRevisionID = @ID  
  