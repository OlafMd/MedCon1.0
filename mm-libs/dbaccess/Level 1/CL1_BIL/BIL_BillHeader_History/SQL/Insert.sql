INSERT INTO 
	bil_billheader_history
	(
		BIL_BillHeader_HistoryID,
		BillHeader_RefID,
		IsCreated,
		IsModified,
		IsSentToCustomer,
		TriggeredBy_BusinessParticipant_RefID,
		Comment,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@BIL_BillHeader_HistoryID,
		@BillHeader_RefID,
		@IsCreated,
		@IsModified,
		@IsSentToCustomer,
		@TriggeredBy_BusinessParticipant_RefID,
		@Comment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)