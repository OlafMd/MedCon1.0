
	SELECT log_wrh_warehouses.LOG_WRH_WarehouseID,
	       log_wrh_warehouses.CoordinateCode,
	       log_wrh_warehouses.Warehouse_Name,
	       log_wrh_warehouses.DeliveryAddress_RefID,
	       log_wrh_warehouses.BoundTo_EconomicRegion_RefID,
	       log_wrh_warehouses.IsStructureHidden,
	       log_wrh_warehouses.IsConsignmentWarehouse,
	       log_wrh_warehouses.IfConsignmentWarehouse_DefaultOwningSupplier_RefID,
	       log_wrh_warehouses.IsDeleted,
         log_wrh_warehouses.IsDefaultShipmentWarehouse,
         log_wrh_warehouse_2_warehousegroup.LOG_WRH_Warehouse_Group_RefID,
         log_wrh_warehouse_defaultsuppliers.CMN_BPT_Supplier_RefID
	  FROM log_wrh_warehouses
         LEFT JOIN log_wrh_warehouse_2_warehousegroup on log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_warehouse_2_warehousegroup.LOG_WRH_Warehouse_RefID AND log_wrh_warehouse_2_warehousegroup.IsDeleted = 0
	       LEFT JOIN log_wrh_warehouse_defaultsuppliers on log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_warehouse_defaultsuppliers.Warehouse_RefID AND log_wrh_warehouse_defaultsuppliers.IsDeleted = 0
   WHERE LOG_WRH_WarehouseID = IFNULL(@WarehouseID, log_wrh_warehouses.LOG_WRH_WarehouseID)
	       AND log_wrh_warehouses.Tenant_RefID = @TenantID
         AND log_wrh_warehouses.IsDeleted = 0
  