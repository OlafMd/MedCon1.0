UPDATE 
	doc_document_2_structure
SET 
	Document_RefID=@Document_RefID,
	Structure_RefID=@Structure_RefID,
	StructureHeader_RefID=@StructureHeader_RefID,
	IsPrimaryLocation=@IsPrimaryLocation,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID