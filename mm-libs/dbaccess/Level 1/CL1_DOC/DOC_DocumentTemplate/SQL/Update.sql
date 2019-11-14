UPDATE 
	doc_documenttemplates
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DisplayName=@DisplayName,
	DocumentTemplate_Name_DictID=@DocumentTemplate_Name,
	DocumentTemplate_Description_DictID=@DocumentTemplate_Description,
	TemplateContent=@TemplateContent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	DOC_DocumentTemplateID = @DOC_DocumentTemplateID