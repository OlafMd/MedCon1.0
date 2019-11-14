UPDATE 
	log_wrh_inj_inventoryjobs
SET 
	Warehouse_RefID=@Warehouse_RefID,
	InventoryJob_DisplayName=@InventoryJob_DisplayName,
	InventoryJob_Name_DictID=@InventoryJob_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_InventoryJobID = @LOG_WRH_INJ_InventoryJobID