INSERT INTO 
	bil_billstatuses
	(
		BIL_BillStatusID,
		GlobalPropertyMatchingID,
		BillStatus_Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@BIL_BillStatusID,
		@GlobalPropertyMatchingID,
		@BillStatus_Name,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)