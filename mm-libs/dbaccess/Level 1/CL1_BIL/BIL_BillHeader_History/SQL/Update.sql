UPDATE 
	bil_billheader_history
SET 
	BillHeader_RefID=@BillHeader_RefID,
	IsCreated=@IsCreated,
	IsModified=@IsModified,
	IsSentToCustomer=@IsSentToCustomer,
	TriggeredBy_BusinessParticipant_RefID=@TriggeredBy_BusinessParticipant_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	BIL_BillHeader_HistoryID = @BIL_BillHeader_HistoryID