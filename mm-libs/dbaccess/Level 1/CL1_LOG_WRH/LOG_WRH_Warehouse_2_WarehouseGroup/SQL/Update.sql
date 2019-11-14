UPDATE 
	log_wrh_warehouse_2_warehousegroup
SET 
	LOG_WRH_Warehouse_RefID=@LOG_WRH_Warehouse_RefID,
	LOG_WRH_Warehouse_Group_RefID=@LOG_WRH_Warehouse_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID