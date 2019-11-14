INSERT INTO 
	doc_document_2_structure
	(
		AssignmentID,
		Document_RefID,
		Structure_RefID,
		StructureHeader_RefID,
		IsPrimaryLocation,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@Document_RefID,
		@Structure_RefID,
		@StructureHeader_RefID,
		@IsPrimaryLocation,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)