
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
    tms_pro_comment_attachedfiles
  On
    tms_pro_comment_attachedfiles.AttachedFile_Document_RefID = doc_documents.DOC_DocumentID    
  And
    tms_pro_comment_attachedfiles.IsDeleted = 0
  Inner Join
    tms_pro_comments 
  On
    tms_pro_comment_attachedfiles.Comment_RefID = tms_pro_comments.TMS_PRO_CommentID     
  Where
    doc_structures.IsDeleted = 0 And
    tms_pro_comments.IsDeleted = 0 And
    tms_pro_comments.Tenant_RefID = @TenantID And
    tms_pro_comments.TMS_PRO_CommentID = @ID  
  