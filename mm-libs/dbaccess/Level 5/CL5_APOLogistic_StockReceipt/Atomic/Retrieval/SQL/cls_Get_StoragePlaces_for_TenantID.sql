
	select 
	  log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID, 
	  log_wrh_warehouse_groups.WarehouseGroup_Name, 
	  log_wrh_warehouses.LOG_WRH_WarehouseID, 
	  log_wrh_warehouses.Warehouse_Name, 
	  log_wrh_areas.LOG_WRH_AreaID, 
	  log_wrh_areas.Area_Name, 
	  log_wrh_areas.Rack_NamePrefix, 
	  log_wrh_racks.LOG_WRH_RackID, 
	  log_wrh_racks.Rack_Name, 
	  log_wrh_racks.Shelf_NamePrefix, 
	  log_wrh_shelves.LOG_WRH_ShelfID, 
	  log_wrh_shelves.Shelf_Name 
	from 
	  log_wrh_warehouse_groups 
	  left join log_wrh_warehouse_2_warehousegroup on log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID = log_wrh_warehouse_2_warehousegroup.LOG_WRH_Warehouse_Group_RefID 
	  and log_wrh_warehouse_groups.IsDeleted = 0 
	  left join log_wrh_warehouses on log_wrh_warehouse_2_warehousegroup.LOG_WRH_Warehouse_RefID = log_wrh_warehouses.LOG_WRH_WarehouseID 
	  and log_wrh_warehouses.IsDeleted = 0 
	  left join log_wrh_areas on log_wrh_warehouses.LOG_WRH_WarehouseID = log_wrh_areas.Warehouse_RefID 
	  and log_wrh_areas.IsDeleted = 0 
	  left join log_wrh_racks on log_wrh_areas.LOG_WRH_AreaID = log_wrh_racks.Area_RefID 
	  and log_wrh_racks.IsDeleted = 0 
	  left join log_wrh_shelves on log_wrh_racks.LOG_WRH_RackID = log_wrh_shelves.Rack_RefID 
	  and log_wrh_shelves.IsDeleted = 0 
	where 
	  log_wrh_warehouse_groups.IsDeleted = 0 
	  and log_wrh_warehouse_groups.Tenant_RefID = @TenantID
  