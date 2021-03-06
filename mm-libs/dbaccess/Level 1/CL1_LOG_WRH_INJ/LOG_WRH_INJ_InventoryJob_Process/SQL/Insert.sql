INSERT INTO 
	log_wrh_inj_inventoryjob_processes
	(
		LOG_WRH_INJ_InventoryJob_ProcessID,
		LOG_WRH_INJ_InventoryJob_RefID,
		SequenceNumber,
		IsBookedIntoStock,
		BookedIntoStock_ByAccount_RefID,
		BookedIntoStock_Date,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_INJ_InventoryJob_ProcessID,
		@LOG_WRH_INJ_InventoryJob_RefID,
		@SequenceNumber,
		@IsBookedIntoStock,
		@BookedIntoStock_ByAccount_RefID,
		@BookedIntoStock_Date,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)