
SELECT
  log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID,
  log_wrh_warehouse_groups.WarehouseGroup_Name,
  log_wrh_warehouses.LOG_WRH_WarehouseID,
  log_wrh_warehouses.Warehouse_Name,
  log_wrh_warehouses.CoordinateCode AS WarehouseCoordinateCode,
  log_wrh_warehouses.IsStructureHidden AS IsWarehouseHidden,
  log_wrh_areas.LOG_WRH_AreaID,
  log_wrh_areas.Area_Name,
  log_wrh_areas.Rack_NamePrefix,
  log_wrh_areas.CoordinateCode AS AreaCoordinateCode,
  log_wrh_areas.IsDefaultIntakeArea,
  log_wrh_areas.IsStructureHidden AS IsAreaHidden,
  log_wrh_racks.LOG_WRH_RackID,
  log_wrh_racks.Rack_Name,
  log_wrh_racks.Shelf_NamePrefix,
  log_wrh_racks.CoordinateCode AS RackCoordinateCode,
  log_wrh_racks.IsStructureHidden AS IsRackHidden,
  log_wrh_shelves.LOG_WRH_ShelfID,
  log_wrh_shelves.Shelf_Name,  
  log_wrh_shelves.CoordinateCode AS ShelfCoordinateCode,
  log_wrh_shelves.Predefined_Product_RefID,
  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
  log_wrh_shelf_contents.Product_RefID,
  log_wrh_shelf_contents.Quantity_Current,
  log_producttrackinginstances.ExpirationDate,
  log_producttrackinginstances.BatchNumber,
  log_producttrackinginstances.CurrentQuantityOnTrackingInstance,
  log_producttrackinginstances.LOG_ProductTrackingInstanceID
FROM log_wrh_warehouse_groups
LEFT JOIN log_wrh_warehouse_2_warehousegroup
  ON log_wrh_warehouse_2_warehousegroup.LOG_WRH_Warehouse_Group_RefID = log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID
  AND log_wrh_warehouse_2_warehousegroup.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_warehouse_2_warehousegroup.IsDeleted = 0
LEFT JOIN log_wrh_warehouses
  ON log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_warehouse_2_warehousegroup.LOG_WRH_Warehouse_RefID
  AND log_wrh_warehouses.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_warehouses.IsDeleted = 0
LEFT JOIN log_wrh_areas
  ON log_wrh_areas.Warehouse_RefID = log_wrh_warehouses.LOG_WRH_WarehouseID
  AND log_wrh_areas.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_areas.IsDeleted = 0
LEFT JOIN log_wrh_racks
  ON log_wrh_racks.Area_RefID = log_wrh_areas.LOG_WRH_AreaID
  AND log_wrh_racks.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_racks.IsDeleted = 0
LEFT JOIN log_wrh_shelves
  ON log_wrh_shelves.Rack_RefID = log_wrh_racks.LOG_WRH_RackID
  AND log_wrh_shelves.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_shelves.IsDeleted = 0
LEFT JOIN log_wrh_shelf_contents
  ON log_wrh_shelf_contents.Shelf_RefID = log_wrh_shelves.LOG_WRH_ShelfID
  AND log_wrh_shelf_contents.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_shelf_contents.IsDeleted = 0
LEFT JOIN log_wrh_shelfcontent_2_trackinginstance
  ON log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID = log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
  AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
LEFT JOIN log_producttrackinginstances
  ON log_producttrackinginstances.LOG_ProductTrackingInstanceID = log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
  AND log_producttrackinginstances.Tenant_RefID = log_wrh_warehouse_groups.Tenant_RefID
  AND log_producttrackinginstances.IsDeleted = 0
WHERE
  log_wrh_warehouse_groups.Tenant_RefID = @TenantID
  AND log_wrh_warehouse_groups.IsDeleted = 0
  AND (@WarehouseGroupID IS NULL OR log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID = @WarehouseGroupID)
  AND (@WarehouseID IS NULL OR log_wrh_warehouses.LOG_WRH_WarehouseID = @WarehouseID)
  AND (@AreaID IS NULL OR log_wrh_areas.LOG_WRH_AreaID = @AreaID)
  AND (@RackID IS NULL OR log_wrh_racks.LOG_WRH_RackID = @RackID)
  AND (@UseShelfIDList = 0 OR log_wrh_shelves.LOG_WRH_ShelfID = @ShelfIDs)
  AND (@UseProductIDList = 0 OR log_wrh_shelf_contents.Product_RefID = @ProductIDs)
  AND (@BottomShelfQuantity IS NULL OR log_wrh_shelf_contents.Quantity_Current >= @BottomShelfQuantity)
  AND (@TopShelfQuantity IS NULL OR log_wrh_shelf_contents.Quantity_Current <= @TopShelfQuantity)
  AND (@UseProductTrackingInstanceIDList = 0 OR log_producttrackinginstances.LOG_ProductTrackingInstanceID = @ProductTrackingInstanceIDs)
  AND (@StartExpirationDate IS NULL OR log_producttrackinginstances.ExpirationDate >= @StartExpirationDate)
  AND (@EndExpirationDate IS NULL OR log_producttrackinginstances.ExpirationDate <= @EndExpirationDate)
  