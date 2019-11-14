UPDATE 
	log_wrh_inj_inventoryjob_process_shelves
SET 
	LOG_WRH_INJ_InventoryJob_Process_RefID=@LOG_WRH_INJ_InventoryJob_Process_RefID,
	LOG_WRH_Shelf_RefID=@LOG_WRH_Shelf_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJob_Process_ShelfID = @LOG_WRH_INJ_InventoryJob_Process_ShelfID