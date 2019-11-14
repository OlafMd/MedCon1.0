UPDATE 
	bil_billheader_2_billstatus
SET 
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	BIL_BillStatus_RefID=@BIL_BillStatus_RefID,
	IsCurrentStatus=@IsCurrentStatus,
	StatusComment=@StatusComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID