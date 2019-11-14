
	SELECT log_wrh_racks.Rack_Name
    ,log_wrh_racks.CoordinateCode AS RackCode
		,log_wrh_areas.Area_Name
    ,log_wrh_areas.CoordinateCode AS AreaCode
		,log_wrh_warehouses.Warehouse_Name
    ,log_wrh_warehouses.CoordinateCode AS WarehouseCode
		,log_wrh_shelves.Shelf_Name
    ,log_wrh_shelves.CoordinateCode AS ShelfCode
    ,log_wrh_shelves.LOG_WRH_ShelfID
	FROM log_wrh_shelves
	INNER JOIN log_wrh_warehouses ON log_wrh_shelves.R_Warehouse_RefID = log_wrh_warehouses.LOG_WRH_WarehouseID
		AND log_wrh_warehouses.Tenant_RefID = @TenantID
		AND log_wrh_warehouses.IsDeleted = 0
	INNER JOIN log_wrh_racks ON log_wrh_shelves.Rack_RefID = log_wrh_racks.LOG_WRH_RackID
		AND log_wrh_racks.Tenant_RefID = @TenantID
		AND log_wrh_racks.IsDeleted = 0
	INNER JOIN log_wrh_areas ON log_wrh_shelves.R_Area_RefID = log_wrh_areas.LOG_WRH_AreaID
		AND log_wrh_areas.Tenant_RefID = @TenantID
		AND log_wrh_areas.IsDeleted = 0
	WHERE log_wrh_shelves.LOG_WRH_ShelfID = @ShelfIDs
		AND log_wrh_shelves.Tenant_RefID = @TenantID
		AND log_wrh_shelves.IsDeleted = 0
  