INSERT INTO 
	log_wrh_inj_inventoryjob_countingruns
	(
		LOG_WRH_INJ_InventoryJob_CountingRunID,
		InventoryJob_Process_RefID,
		ExecutingBusinessParticipant_RefID,
		SequenceNumber,
		IsCounting_Started,
		IsCounting_Completed,
		IsCountingListPrinted,
		IsDifferenceFound,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_INJ_InventoryJob_CountingRunID,
		@InventoryJob_Process_RefID,
		@ExecutingBusinessParticipant_RefID,
		@SequenceNumber,
		@IsCounting_Started,
		@IsCounting_Completed,
		@IsCountingListPrinted,
		@IsDifferenceFound,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)