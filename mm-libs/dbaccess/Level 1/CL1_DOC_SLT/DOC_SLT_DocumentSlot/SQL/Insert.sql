INSERT INTO 
	doc_slt_documentslot
	(
		DOC_SLT_DocumentSlotID,
		GlobalPropertyMatchingID,
		Document_Name_DictID,
		IsRequired,
		HasMimeTypeRestrictions,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@DOC_SLT_DocumentSlotID,
		@GlobalPropertyMatchingID,
		@Document_Name,
		@IsRequired,
		@HasMimeTypeRestrictions,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)