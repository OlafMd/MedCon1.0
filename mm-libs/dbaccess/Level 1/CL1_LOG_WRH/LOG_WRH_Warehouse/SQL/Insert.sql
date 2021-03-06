INSERT INTO 
	log_wrh_warehouses
	(
		LOG_WRH_WarehouseID,
		GlobalPropertyMatchingID,
		CoordinateCode,
		Warehouse_Name,
		DeliveryAddress_RefID,
		BoundTo_Office_RefID,
		BoundTo_EconomicRegion_RefID,
		IsStructureHidden,
		IsConsignmentWarehouse,
		IfConsignmentWarehouse_DefaultOwningSupplier_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		IsDefaultShipmentWarehouse
	)
VALUES 
	(
		@LOG_WRH_WarehouseID,
		@GlobalPropertyMatchingID,
		@CoordinateCode,
		@Warehouse_Name,
		@DeliveryAddress_RefID,
		@BoundTo_Office_RefID,
		@BoundTo_EconomicRegion_RefID,
		@IsStructureHidden,
		@IsConsignmentWarehouse,
		@IfConsignmentWarehouse_DefaultOwningSupplier_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@IsDefaultShipmentWarehouse
	)