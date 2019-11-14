UPDATE 
	doc_structuretemplate_header
SET 
	Name_DictID=@Name,
	Description_DictID=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	DOC_StructureTemplateID = @DOC_StructureTemplateID