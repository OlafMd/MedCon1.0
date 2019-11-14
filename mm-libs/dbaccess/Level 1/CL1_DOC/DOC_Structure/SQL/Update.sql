UPDATE 
	doc_structures
SET 
	Label=@Label,
	Structure_Header_RefID=@Structure_Header_RefID,
	Parent_RefID=@Parent_RefID,
	CreatedBy_Account_RefID=@CreatedBy_Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	DOC_StructureID = @DOC_StructureID