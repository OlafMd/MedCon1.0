INSERT INTO 
	log_dlv_delivery_positions
	(
		LOG_DLV_Delivery_PositionID,
		DeliveryHeader_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_DLV_Delivery_PositionID,
		@DeliveryHeader_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)