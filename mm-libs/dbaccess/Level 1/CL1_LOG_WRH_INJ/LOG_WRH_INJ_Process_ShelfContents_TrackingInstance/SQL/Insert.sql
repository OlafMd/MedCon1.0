INSERT INTO 
	log_wrh_inj_process_shelfcontents_trackinginstances
	(
		LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID,
		LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID,
		LOG_ProductTrackingInstance_RefID,
		ExpectedQuantityOnTrackingInstance,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_INJ_Process_ShelfContents_TrackingInstanceID,
		@LOG_WRH_INJ_InventoryJob_Process_ShelfContent_RefID,
		@LOG_ProductTrackingInstance_RefID,
		@ExpectedQuantityOnTrackingInstance,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)