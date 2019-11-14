UPDATE 
	doc_documenttemplate_placeholders
SET 
	DocumentTemplate_RefID=@DocumentTemplate_RefID,
	Placeholder=@Placeholder,
	DisplayName=@DisplayName,
	PlaceholderName_DictID=@PlaceholderName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	DOC_DocumentTemplate_PlaceholderID = @DOC_DocumentTemplate_PlaceholderID