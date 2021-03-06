INSERT INTO 
	log_rsv_reservation_trackinginstances
	(
		LOG_RSV_Reservation_TrackingInstanceID,
		LOG_RSV_Reservation_RefID,
		LOG_ProductTrackingInstance_RefID,
		ReservedQuantityFromTrackingInstance,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_RSV_Reservation_TrackingInstanceID,
		@LOG_RSV_Reservation_RefID,
		@LOG_ProductTrackingInstance_RefID,
		@ReservedQuantityFromTrackingInstance,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)