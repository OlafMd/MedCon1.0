INSERT INTO 
	bil_billheader_2_billstatus
	(
		AssignmentID,
		BIL_BillHeader_RefID,
		BIL_BillStatus_RefID,
		IsCurrentStatus,
		StatusComment,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@AssignmentID,
		@BIL_BillHeader_RefID,
		@BIL_BillStatus_RefID,
		@IsCurrentStatus,
		@StatusComment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)