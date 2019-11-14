
	Select
	  log_wrh_inj_inventoryjobs.MemberOf_InventoryJobSeries_RefID,
	  log_wrh_inj_inventoryjobs.InventoryJob_DisplayName,
	  log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID,
	  log_wrh_inj_inventoryjobs.Warehouse_RefID,
	  log_wrh_inj_inventoryjobs.IsInventoryJobCompleted
	From
	  log_wrh_inj_inventoryjobs Inner Join
	  log_wrh_inj_inventoryjob_processes
	    On log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_RefID =
	    log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID   
	Where
	 log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_ProcessID = @ProcessID And
	 log_wrh_inj_inventoryjob_processes.Tenant_RefID = @TenantID And
	 log_wrh_inj_inventoryjob_processes.isDeleted = 0 
  