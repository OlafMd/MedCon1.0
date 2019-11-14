
Select
  log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID,
  log_wrh_inj_inventoryjobs.InventoryJob_DisplayName,
  log_wrh_inj_inventoryjobs.InventoryJob_Name_DictID,
  log_wrh_inj_inventoryjobs.Warehouse_RefID,
  log_wrh_warehouses.Warehouse_Name
From
  log_wrh_inj_inventoryjobs Inner Join
  log_wrh_warehouses On log_wrh_inj_inventoryjobs.Warehouse_RefID =
    log_wrh_warehouses.LOG_WRH_WarehouseID
Where
  log_wrh_inj_inventoryjobs.IsDeleted = 0 And
  log_wrh_inj_inventoryjobs.Tenant_RefID = @TenantID
Group By
  log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID

  