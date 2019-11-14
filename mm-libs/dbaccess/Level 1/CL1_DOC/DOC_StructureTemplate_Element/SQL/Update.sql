UPDATE 
	doc_structuretemplate_elements
SET 
	Template_Header_RefID=@Template_Header_RefID,
	Label_DictID=@Label,
	Parent_RefID=@Parent_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	DOC_StructureTemplate_ElementID = @DOC_StructureTemplate_ElementID