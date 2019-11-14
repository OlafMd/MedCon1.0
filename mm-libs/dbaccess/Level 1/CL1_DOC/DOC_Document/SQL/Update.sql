UPDATE 
	doc_documents
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Alias=@Alias,
	PrimaryType=@PrimaryType,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	DOC_DocumentID = @DOC_DocumentID