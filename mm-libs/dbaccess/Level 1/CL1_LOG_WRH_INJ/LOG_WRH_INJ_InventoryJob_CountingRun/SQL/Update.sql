UPDATE 
	log_wrh_inj_inventoryjob_countingruns
SET 
	InventoryJob_Process_RefID=@InventoryJob_Process_RefID,
	ExecutingBusinessParticipant_RefID=@ExecutingBusinessParticipant_RefID,
	SequenceNumber=@SequenceNumber,
	IsCounting_Started=@IsCounting_Started,
	IsCounting_Completed=@IsCounting_Completed,
	IsCountingListPrinted=@IsCountingListPrinted,
	IsDifferenceFound=@IsDifferenceFound,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_CountingRunID = @LOG_WRH_INJ_InventoryJob_CountingRunID