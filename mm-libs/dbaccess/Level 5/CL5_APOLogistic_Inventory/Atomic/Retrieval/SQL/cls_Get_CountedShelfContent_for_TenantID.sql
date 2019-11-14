
Select
  Count(log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID) As CountedShelfContentForInventory,
  log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_RefID
From
  log_wrh_inj_inventoryjob_processes Left Join
  log_wrh_inj_inventoryjob_process_shelves
    On log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_ProcessID =
    log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_INJ_InventoryJob_Process_RefID And log_wrh_inj_inventoryjob_process_shelves.Tenant_RefID = @TenantID Left Join
  log_wrh_shelf_contents
    On log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_Shelf_RefID =
    log_wrh_shelf_contents.Shelf_RefID And log_wrh_shelf_contents.Tenant_RefID =
    @TenantID
Where
  log_wrh_inj_inventoryjob_processes.IsBookedIntoStock = 1 And
  log_wrh_inj_inventoryjob_processes.Tenant_RefID = @TenantID And
  log_wrh_inj_inventoryjob_processes.IsDeleted = 0
Group By
  log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_RefID
  