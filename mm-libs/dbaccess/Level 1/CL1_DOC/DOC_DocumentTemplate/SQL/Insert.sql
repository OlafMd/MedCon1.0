INSERT INTO 
	doc_documenttemplates
	(
		DOC_DocumentTemplateID,
		GlobalPropertyMatchingID,
		DisplayName,
		DocumentTemplate_Name_DictID,
		DocumentTemplate_Description_DictID,
		TemplateContent,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@DOC_DocumentTemplateID,
		@GlobalPropertyMatchingID,
		@DisplayName,
		@DocumentTemplate_Name,
		@DocumentTemplate_Description,
		@TemplateContent,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)