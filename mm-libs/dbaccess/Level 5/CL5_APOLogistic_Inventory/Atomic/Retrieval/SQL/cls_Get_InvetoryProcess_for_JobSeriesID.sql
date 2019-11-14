
	Select
	  log_wrh_inj_inventoryjobs.LOG_WRH_INJ_InventoryJobID,
    log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_ProcessID,
	  log_wrh_inj_inventoryjob_processes.Creation_Timestamp,
	  log_wrh_inj_inventoryjob_countingruns.SequenceNumber,
    log_wrh_inj_inventoryjob_countingruns.LOG_WRH_INJ_InventoryJob_CountingRunID,
	  log_wrh_inj_inventoryjob_countingruns.IsCounting_Started,
	  log_wrh_inj_inventoryjob_countingruns.IsCounting_Completed,
	  log_wrh_inj_inventoryjob_countingruns.IsCountingListPrinted
	From
	  log_wrh_inj_inventoryjobs Inner Join
	  log_wrh_inj_inventoryjob_processes
	    On log_wrh_inj_inventoryjobs.MemberOf_InventoryJobSeries_RefID =
	    log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_ProcessID And
	    log_wrh_inj_inventoryjob_processes.Tenant_RefID = @TenantID And
	    log_wrh_inj_inventoryjob_processes.IsDeleted = 0
	  Inner Join
	  log_wrh_inj_inventoryjob_countingruns
	    On log_wrh_inj_inventoryjob_processes.LOG_WRH_INJ_InventoryJob_ProcessID =
	    log_wrh_inj_inventoryjob_countingruns.InventoryJob_Process_RefID And
	    log_wrh_inj_inventoryjob_countingruns.Tenant_RefID = @TenantID And
	    log_wrh_inj_inventoryjob_countingruns.IsDeleted = 0
	Where
	  log_wrh_inj_inventoryjobs.MemberOf_InventoryJobSeries_RefID = @InventoryJobSeries_RefID And
	  log_wrh_inj_inventoryjobs.Tenant_RefID = @TenantID And
	  log_wrh_inj_inventoryjobs.IsDeleted = 0
  