
	SELECT
	  log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_Shelf_RefID
	FROM
	  log_wrh_inj_inventoryjob_processes
	  LEFT JOIN log_wrh_inj_inventoryjobs
	    ON log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID =
	         log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_RefID AND
	       log_wrh_inj_inventoryjob_processes.Tenant_RefID =
	         log_wrh_inj_inventoryjobs.Tenant_RefID AND
	       log_wrh_inj_inventoryjob_processes.IsDeleted = 0
	  LEFT JOIN log_wrh_inj_inventoryjob_process_shelves
	    ON log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_ProcessID =
	         log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_INJ_InventoryJob_Process_RefID AND
	       log_wrh_inj_inventoryjob_process_shelves.Tenant_RefID =
	         log_wrh_inj_inventoryjob_processes.Tenant_RefID AND
	       log_wrh_inj_inventoryjob_process_shelves.IsDeleted = 0
	WHERE
	  log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID = @InventoryJobID AND
	  log_wrh_inj_inventoryjobs.Tenant_RefID = @TenantID AND
	  log_wrh_inj_inventoryjobs.IsDeleted = 0

  