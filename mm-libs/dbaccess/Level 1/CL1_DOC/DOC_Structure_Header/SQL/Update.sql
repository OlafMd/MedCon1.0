UPDATE 
	doc_structure_headers
SET 
	Label=@Label,
	DocumentStructureRoot_RefID=@DocumentStructureRoot_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	DOC_Structure_HeaderID = @DOC_Structure_HeaderID