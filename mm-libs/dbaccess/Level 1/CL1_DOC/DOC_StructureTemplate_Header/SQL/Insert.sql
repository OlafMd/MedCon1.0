INSERT INTO 
	doc_structuretemplate_header
	(
		DOC_StructureTemplateID,
		Name_DictID,
		Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@DOC_StructureTemplateID,
		@Name,
		@Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)