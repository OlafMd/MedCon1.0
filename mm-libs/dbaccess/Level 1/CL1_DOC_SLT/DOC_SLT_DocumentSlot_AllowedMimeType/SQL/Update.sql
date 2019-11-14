UPDATE 
	doc_slt_documentslot_allowedmimetypes
SET 
	DOC_SLT_DocumentSlot_RefID=@DOC_SLT_DocumentSlot_RefID,
	DOC_MimeType_RefID=@DOC_MimeType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	DOC_SLT_DocumentSlot_AllowedMimeTypeID = @DOC_SLT_DocumentSlot_AllowedMimeTypeID