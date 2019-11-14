
	Select
	  log_wrh_shelf_contents.Quantity_Current,
	  log_producttrackinginstances.BatchNumber,
	  log_producttrackinginstances.ExpirationDate,
	  log_wrh_racks.Rack_Name,
	  log_wrh_shelves.Shelf_Name,
	  log_wrh_areas.Area_Name,
	  log_wrh_warehouses.Warehouse_Name,
	  log_producttrackinginstances.LOG_ProductTrackingInstanceID,
	  log_producttrackinginstances.CurrentQuantityOnTrackingInstance,
	  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
	  log_wrh_shelf_contents.Product_RefID
	From
	  log_wrh_shelf_contents Inner Join
	  log_wrh_shelves On log_wrh_shelf_contents.Shelf_RefID =
	    log_wrh_shelves.LOG_WRH_ShelfID And log_wrh_shelves.Tenant_RefID = @TenantID
	  Inner Join
	  log_wrh_warehouses On log_wrh_shelves.R_Warehouse_RefID =
	    log_wrh_warehouses.LOG_WRH_WarehouseID And log_wrh_warehouses.Tenant_RefID =
	    @TenantID And log_wrh_warehouses.IsDeleted = 0 Inner Join
	  log_wrh_racks On log_wrh_shelves.Rack_RefID = log_wrh_racks.LOG_WRH_RackID And
	    log_wrh_racks.Tenant_RefID = @TenantID And log_wrh_racks.IsDeleted = 0
	  Inner Join
	  log_wrh_areas On log_wrh_shelves.R_Area_RefID = log_wrh_areas.LOG_WRH_AreaID
	    And log_wrh_areas.Tenant_RefID = @TenantID And log_wrh_areas.IsDeleted = 0
	  Left Join
	  log_wrh_shelfcontent_2_trackinginstance
	    On log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID =
	    log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID
	  Left Join
	  log_producttrackinginstances
	    On log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
	    = log_producttrackinginstances.LOG_ProductTrackingInstanceID And
	    log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
	Where
	  log_wrh_shelf_contents.Product_RefID = @ProductID And
	  log_wrh_shelf_contents.Tenant_RefID = @TenantID And  
	  log_wrh_shelf_contents.IsDeleted = 0
  