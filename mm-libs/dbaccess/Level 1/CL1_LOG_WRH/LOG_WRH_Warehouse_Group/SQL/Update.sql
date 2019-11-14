UPDATE 
	log_wrh_warehouse_groups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Parent_RefID=@Parent_RefID,
	WarehouseGroup_Name=@WarehouseGroup_Name,
	WarehouseGroup_Description_DictID=@WarehouseGroup_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_Warehouse_GroupID = @LOG_WRH_Warehouse_GroupID