UPDATE 
	log_wrh_warehouses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	CoordinateCode=@CoordinateCode,
	Warehouse_Name=@Warehouse_Name,
	DeliveryAddress_RefID=@DeliveryAddress_RefID,
	BoundTo_Office_RefID=@BoundTo_Office_RefID,
	BoundTo_EconomicRegion_RefID=@BoundTo_EconomicRegion_RefID,
	IsStructureHidden=@IsStructureHidden,
	IsConsignmentWarehouse=@IsConsignmentWarehouse,
	IfConsignmentWarehouse_DefaultOwningSupplier_RefID=@IfConsignmentWarehouse_DefaultOwningSupplier_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	IsDefaultShipmentWarehouse=@IsDefaultShipmentWarehouse
WHERE 
	LOG_WRH_WarehouseID = @LOG_WRH_WarehouseID