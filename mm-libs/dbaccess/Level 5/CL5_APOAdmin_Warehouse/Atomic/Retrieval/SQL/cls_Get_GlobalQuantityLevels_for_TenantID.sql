
Select
  log_wrh_warehouses.LOG_WRH_WarehouseID,
  log_wrh_warehouse_2_quantitylevels.AssignmentID,
  log_wrh_quantitylevels.Quantity_RecommendedMinimumCalculation,
  log_wrh_quantitylevels.Quantity_Minimum,
  log_wrh_warehouses.Warehouse_Name,
  log_wrh_quantitylevels.LOG_WRH_QuantityLevelID
From
  log_wrh_warehouses Left Join
  log_wrh_warehouse_2_quantitylevels On log_wrh_warehouses.LOG_WRH_WarehouseID =
    log_wrh_warehouse_2_quantitylevels.LOG_WRH_Warehouse_RefID Left Join
  log_wrh_quantitylevels On log_wrh_quantitylevels.LOG_WRH_QuantityLevelID =
    log_wrh_warehouse_2_quantitylevels.LOG_WRH_QuantityLevel_RefID
Where
  log_wrh_warehouses.Tenant_RefID = @TenantID And
  log_wrh_warehouses.IsDeleted = 0 
  
  