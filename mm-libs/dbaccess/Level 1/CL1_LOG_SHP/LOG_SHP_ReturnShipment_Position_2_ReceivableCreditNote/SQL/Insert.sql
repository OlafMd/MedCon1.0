INSERT INTO 
	log_shp_returnshipment_position_2_receivablecreditnote
	(
		AssignmentID,
		LOG_SHP_ReturnShipment_Position_RefID,
		LOG_SHP_ReturnShipment_ReceivableCreditNotes_Position_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@LOG_SHP_ReturnShipment_Position_RefID,
		@LOG_SHP_ReturnShipment_ReceivableCreditNotes_Position_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)