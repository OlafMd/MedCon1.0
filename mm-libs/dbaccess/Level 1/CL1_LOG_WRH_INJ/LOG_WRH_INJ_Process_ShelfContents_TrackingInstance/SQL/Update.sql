UPDATE 
	log_wrh_inj_process_shelfcontents_trackinginstances
SET 
	LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID=@LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID,
	LOG_ProductTrackingInstance_RefID=@LOG_ProductTrackingInstance_RefID,
	ExpectedQuantityOnTrackingInstance=@ExpectedQuantityOnTrackingInstance,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID = @LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID