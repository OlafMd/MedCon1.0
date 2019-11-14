UPDATE 
	bil_billheaderextension_edifact
SET 
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	EDIFACTCounter=@EDIFACTCounter,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	BIL_BillHeaderExtension_EDIFACTID = @BIL_BillHeaderExtension_EDIFACTID