INSERT INTO 
	log_wrh_shelf_contentadjustment_trackinginstances
	(
		LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID,
		LOG_WRH_Shelf_ContentAdjustment_RefID,
		LOG_ProductTrackingInstance_RefID,
		QuantityChangedAmount,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID,
		@LOG_WRH_Shelf_ContentAdjustment_RefID,
		@LOG_ProductTrackingInstance_RefID,
		@QuantityChangedAmount,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)