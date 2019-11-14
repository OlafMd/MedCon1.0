  
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
      doc_documents 
    Inner Join
      tms_pro_comment_attachedfiles     
    on    
      tms_pro_comment_attachedfiles.AttachedFile_Document_RefID = doc_documents.DOC_DocumentID
    Inner Join
      tms_pro_comments    
    on
      tms_pro_comment_attachedfiles.Comment_RefID = tms_pro_comments.TMS_PRO_CommentID   
    Left Join
      doc_documentrevisions 
    on 
      doc_documents.DOC_DocumentID = doc_documentrevisions.Document_RefID    
	  Inner Join
        doc_document_2_structure 
	  on 
	    doc_documents.DOC_DocumentID = doc_document_2_structure.Document_RefID  
    Where
      doc_documents.IsDeleted = 0  And                   
      tms_pro_comments.IsDeleted = 0 And
      tms_pro_comments.Tenant_RefID = @TenantID And
      tms_pro_comments.TMS_PRO_CommentID = @ID And
      (doc_documentrevisions.IsDeleted Is Null Or
        doc_documentrevisions.IsDeleted = 0)
    Order By
      doc_documents.Alias,
      doc_document_2_structure.Structure_RefID  
  