INSERT INTO 
	doc_structure_headers
	(
		DOC_Structure_HeaderID,
		Label,
		DocumentStructureRoot_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@DOC_Structure_HeaderID,
		@Label,
		@DocumentStructureRoot_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)