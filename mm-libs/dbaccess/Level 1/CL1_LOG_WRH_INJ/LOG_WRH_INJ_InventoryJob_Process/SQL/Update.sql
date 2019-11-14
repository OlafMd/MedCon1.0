UPDATE 
	log_wrh_inj_inventoryjob_processes
SET 
	LOG_WRH_INJ_InventoryJob_RefID=@LOG_WRH_INJ_InventoryJob_RefID,
	SequenceNumber=@SequenceNumber,
	IsBookedIntoStock=@IsBookedIntoStock,
	BookedIntoStock_ByAccount_RefID=@BookedIntoStock_ByAccount_RefID,
	BookedIntoStock_Date=@BookedIntoStock_Date,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_ProcessID = @LOG_WRH_INJ_InventoryJob_ProcessID