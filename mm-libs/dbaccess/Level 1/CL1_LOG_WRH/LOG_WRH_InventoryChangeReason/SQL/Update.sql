UPDATE 
	log_wrh_inventorychangereasons
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	InventoryChange_Name_DictID=@InventoryChange_Name,
	InventoryChange_Description_DictID=@InventoryChange_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_InventoryChangeReasonID = @LOG_WRH_InventoryChangeReasonID