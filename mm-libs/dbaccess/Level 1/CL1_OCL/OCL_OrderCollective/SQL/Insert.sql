INSERT INTO 
	ocl_ordercollectives
	(
		OCL_OrderCollectiveID,
		OrderCollectiveITL,
		OrderCollective_Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@OCL_OrderCollectiveID,
		@OrderCollectiveITL,
		@OrderCollective_Name,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)