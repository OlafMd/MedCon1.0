INSERT INTO 
	log_shp_returnshipment_headers
	(
		LOG_SHP_ReturnShipment_HeaderID,
		Ext_Shipment_Header_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_SHP_ReturnShipment_HeaderID,
		@Ext_Shipment_Header_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)