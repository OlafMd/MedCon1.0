INSERT INTO 
	log_shp_shipment_statuses
	(
		LOG_SHP_Shipment_StatusID,
		GlobalPropertyMatchingID,
		Status_Code,
		Status_Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_SHP_Shipment_StatusID,
		@GlobalPropertyMatchingID,
		@Status_Code,
		@Status_Name,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)