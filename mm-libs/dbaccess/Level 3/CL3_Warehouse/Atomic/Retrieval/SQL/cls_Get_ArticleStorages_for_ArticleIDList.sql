
		Select
		  log_wrh_quantitylevels.LOG_WRH_QuantityLevelID,
		  log_wrh_quantitylevels.Quantity_Minimum,
		  log_wrh_quantitylevels.Quantity_RecommendedMinimumCalculation,
		  log_wrh_quantitylevels.Quantity_Maximum,
		  log_wrh_quantitylevels.Product_RefID As ArticleID,
		  log_wrh_area_2_quantitylevels.LOG_WRH_Area_RefID As QLAreaID,
		  log_wrh_rack_2_quantitylevels.LOG_WRH_Rack_RefID As QLRackID,
		  log_wrh_shelf_2_quantitylevels.LOG_WRH_Shelf_RefID As QLShelfID,
		  log_wrh_shelves.LOG_WRH_ShelfID AS ShelfID,
      Coalesce(log_wrh_areas.Warehouse_refID, log_wrh_areas2.Warehouse_refID, log_wrh_areas3.Warehouse_refID) As WarehouseID,
		  Coalesce(log_wrh_areas.LOG_WRH_AreaID, log_wrh_areas2.LOG_WRH_AreaID, log_wrh_areas3.LOG_WRH_AreaID) As AreaID,
		  Coalesce(log_wrh_racks.LOG_WRH_RackID, log_wrh_racks2.LOG_WRH_RackID) As RackID,
		  Coalesce(log_wrh_areas.IsPointOfSalesArea, log_wrh_areas2.IsPointOfSalesArea, log_wrh_areas3.IsPointOfSalesArea) As IsPointOfSalesArea,
		  Coalesce(log_wrh_areas.IsLongTermStorageArea, log_wrh_areas2.IsLongTermStorageArea, log_wrh_areas3.IsLongTermStorageArea) As IsLongTermStorageArea,
		  Coalesce(log_wrh_areas.CoordinateCode, log_wrh_areas2.CoordinateCode, log_wrh_areas3.CoordinateCode ) As AreaCode,
		  Coalesce(log_wrh_racks.CoordinateCode, log_wrh_racks2.CoordinateCode) As RackCode,
		  log_wrh_shelves.CoordinateCode As ShelfCode,
      Coalesce(log_wrh_warehouses.CoordinateCode, log_wrh_warehouses2.CoordinateCode, log_wrh_warehouses3.CoordinateCode) AS WarehouseCode
		From
		  log_wrh_quantitylevels Left Outer Join
		  log_wrh_area_2_quantitylevels
		  On log_wrh_area_2_quantitylevels.LOG_WRH_QuantityLevel_RefID =
		  log_wrh_quantitylevels.LOG_WRH_QuantityLevelID And
		  log_wrh_area_2_quantitylevels.IsDeleted = 0 And
		  log_wrh_area_2_quantitylevels.Tenant_RefID = @TenantID Left Outer Join
		  log_wrh_areas On log_wrh_area_2_quantitylevels.LOG_WRH_Area_RefID =
		  log_wrh_areas.LOG_WRH_AreaID And log_wrh_areas.IsDeleted = 0 And
		  log_wrh_areas.Tenant_RefID = @TenantID Left Outer Join
		  log_wrh_rack_2_quantitylevels
		  On log_wrh_rack_2_quantitylevels.LOG_WRH_QuantityLevel_RefID =
		  log_wrh_quantitylevels.LOG_WRH_QuantityLevelID And
		  log_wrh_rack_2_quantitylevels.IsDeleted = 0 And
		  log_wrh_rack_2_quantitylevels.Tenant_RefID = @TenantID Left Outer Join
		  log_wrh_racks On log_wrh_rack_2_quantitylevels.LOG_WRH_Rack_RefID = log_wrh_racks.LOG_WRH_RackID
		  And log_wrh_racks.IsDeleted = 0 And
		  log_wrh_racks.Tenant_RefID = @TenantID Left Outer Join 
		  log_wrh_areas As log_wrh_areas2 On log_wrh_racks.Area_RefID = log_wrh_areas2.LOG_WRH_AreaID Left Outer Join
		  log_wrh_shelf_2_quantitylevels
		  On log_wrh_shelf_2_quantitylevels.LOG_WRH_QuantityLevel_RefID =
		  log_wrh_quantitylevels.LOG_WRH_QuantityLevelID And
		  log_wrh_shelf_2_quantitylevels.IsDeleted = 0 And
		  log_wrh_shelf_2_quantitylevels.Tenant_RefID = @TenantID Left Outer Join
		  log_wrh_shelves On log_wrh_shelf_2_quantitylevels.LOG_WRH_Shelf_RefID =
		  log_wrh_shelves.LOG_WRH_ShelfID And log_wrh_shelves.IsDeleted = 0 And
		  log_wrh_shelves.Tenant_RefID = @TenantID Left Outer Join
		  log_wrh_areas As log_wrh_areas3 On log_wrh_shelves.R_Area_RefID = log_wrh_areas3.LOG_WRH_AreaID 
		  Left Outer Join
		  log_wrh_racks As log_wrh_racks2 On log_wrh_shelves.Rack_RefID = log_wrh_racks2.LOG_WRH_RackID
      LEFT OUTER JOIN log_wrh_warehouses on log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_areas.Warehouse_RefID
      LEFT OUTER JOIN log_wrh_warehouses AS log_wrh_warehouses2 on log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_areas2.Warehouse_RefID
      LEFT OUTER JOIN log_wrh_warehouses AS log_wrh_warehouses3 on log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_areas3.Warehouse_RefID
		Where
		  log_wrh_quantitylevels.Product_RefID = @ArticleID_List And
		  log_wrh_quantitylevels.IsDeleted = 0 And
		  log_wrh_quantitylevels.Tenant_RefID = @TenantID
  