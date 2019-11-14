UPDATE 
	ecm_doc_generaldocuments
SET 
	DocumentMatchingID=@DocumentMatchingID,
	DocumentTypeMatchingID=@DocumentTypeMatchingID,
	Document_RefID=@Document_RefID,
	IsPublicallyVisible=@IsPublicallyVisible,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ECM_DOC_GeneralDocumentID = @ECM_DOC_GeneralDocumentID