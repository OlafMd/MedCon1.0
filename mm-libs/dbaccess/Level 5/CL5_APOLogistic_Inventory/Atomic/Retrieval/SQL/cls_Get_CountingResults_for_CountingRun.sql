
	Select
	  log_wrh_inj_inventryjob_countingresults.CountingRun_RefID,
	  log_wrh_inj_inventryjob_countingresults.LOG_WRH_INJ_InventoryJob_CountingResultID,
	  log_producttrackinginstances.CurrentQuantityOnTrackingInstance As
	  TrackingInstance_CurrentQuantity,
	  log_producttrackinginstances.BatchNumber,
	  log_wrh_inj_countingresult_trackinginstances.CountedAmount As
	  TrackingInstance_CountedAmount,
	  log_wrh_inj_inventryjob_countingresults.CountedAmount As Shelf_CountedAmount,
	  log_wrh_inj_inventryjob_countingresults.IsDifferenceToExpectedQuantityFound As
	  Shelf_DifferenceFound,
	  log_wrh_inj_countingresult_trackinginstances.IsDifferenceToExpectedQuantityFound As TrackingInstance_DifferenceFound,
	  log_wrh_inj_countingresult_trackinginstances.LOG_WRH_INJ_CountingResult_TrackingInstanceID,
	  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
	  log_producttrackinginstances.LOG_ProductTrackingInstanceID,
    log_wrh_shelf_contents.Quantity_Current as Shelf_CurrentQuantity
	From
	  log_wrh_inj_inventryjob_countingresults Left Join
	  log_wrh_inj_countingresult_trackinginstances
	    On
	    log_wrh_inj_inventryjob_countingresults.LOG_WRH_INJ_InventoryJob_CountingResultID = log_wrh_inj_countingresult_trackinginstances.LOG_WRH_INJ_InventoryJob_CountingResult_RefID 
	    And log_wrh_inj_countingresult_trackinginstances.IsDeleted = 0 And log_wrh_inj_countingresult_trackinginstances.Tenant_RefID = @TenantID
	    Left Join
	  log_producttrackinginstances
	    On
	    log_wrh_inj_countingresult_trackinginstances.LOG_ProductTrackingInstanceID =
	    log_producttrackinginstances.LOG_ProductTrackingInstanceID 
	    
	    And log_producttrackinginstances.IsDeleted = 0 And log_producttrackinginstances.Tenant_RefID = @TenantID
	    Left Join
	  log_wrh_shelfcontent_2_trackinginstance
	    On log_producttrackinginstances.LOG_ProductTrackingInstanceID =
	    log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID And log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0 And log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
	  Left Join
	  log_wrh_shelf_contents
	    On log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID =
	    log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID And log_wrh_shelf_contents.IsDeleted = 0 And log_wrh_shelf_contents.Tenant_RefID = @TenantID
	Where
	  log_wrh_inj_inventryjob_countingresults.CountingRun_RefID = @CountingRunID
	  and log_wrh_inj_inventryjob_countingresults.IsDeleted = 0
	  and log_wrh_inj_inventryjob_countingresults.Tenant_RefID = @TenantID
  