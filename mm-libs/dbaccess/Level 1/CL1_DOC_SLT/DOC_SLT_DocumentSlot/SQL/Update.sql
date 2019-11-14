UPDATE 
	doc_slt_documentslot
SET 
	Document_Name_DictID=@Document_Name,
	IsRequired=@IsRequired,
	HasMimeTypeRestrictions=@HasMimeTypeRestrictions,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	DOC_SLT_DocumentSlotID = @DOC_SLT_DocumentSlotID