INSERT INTO 
	doc_documenttemplate_instance_placeholdervalues
	(
		DOC_DocumentTemplate_Instance_PlaceholderValueID,
		DOC_DocumentTemplate_Instance_RefID,
		DOC_DocumentTemplate_Placeholder_RefID,
		Placeholder_Value,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@DOC_DocumentTemplate_Instance_PlaceholderValueID,
		@DOC_DocumentTemplate_Instance_RefID,
		@DOC_DocumentTemplate_Placeholder_RefID,
		@Placeholder_Value,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)