INSERT INTO 
	log_dlv_delivery_headers
	(
		LOG_DLV_Delivery_HeaderID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_DLV_Delivery_HeaderID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)