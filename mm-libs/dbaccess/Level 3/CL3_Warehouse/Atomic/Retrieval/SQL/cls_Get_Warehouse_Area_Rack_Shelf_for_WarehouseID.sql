
	SELECT
	  log_wrh_warehouses.LOG_WRH_WarehouseID,
	  log_wrh_warehouses.Warehouse_Name,
	  log_wrh_warehouses.IsStructureHidden AS IsWarehouseHidden,
	  log_wrh_areas.LOG_WRH_AreaID,
	  log_wrh_areas.Area_Name,
	  log_wrh_areas.Rack_NamePrefix,
	  log_wrh_areas.IsStructureHidden AS IsAreaHidden,
	  log_wrh_racks.LOG_WRH_RackID,
	  log_wrh_racks.Rack_Name,
	  log_wrh_racks.Shelf_NamePrefix,
	  log_wrh_racks.IsStructureHidden AS IsRackHidden,
	  log_wrh_shelves.LOG_WRH_ShelfID,
	  log_wrh_shelves.Shelf_Name
	FROM
	  log_wrh_warehouses
	  LEFT JOIN log_wrh_areas
	    ON log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_areas.Warehouse_RefID AND
	       log_wrh_areas.IsDeleted = 0
	  LEFT JOIN log_wrh_racks
	    ON log_wrh_areas.LOG_WRH_AreaID = log_wrh_racks.Area_RefID AND
	       log_wrh_racks.IsDeleted = 0
	  LEFT JOIN log_wrh_shelves
	    ON log_wrh_racks.LOG_WRH_RackID = log_wrh_shelves.Rack_RefID AND
	       log_wrh_shelves.IsDeleted = 0
	WHERE 
	log_wrh_warehouses.LOG_WRH_WarehouseID = @WarehouseID
	AND log_wrh_warehouses.IsDeleted = 0
	AND log_wrh_warehouses.Tenant_RefID = @TenantID

  