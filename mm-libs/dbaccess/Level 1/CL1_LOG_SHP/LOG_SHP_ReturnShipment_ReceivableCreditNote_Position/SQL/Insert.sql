INSERT INTO 
	log_shp_returnshipment_receivablecreditnote_positions
	(
		LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID,
		LOG_SHP_ReturnShipment_CreditNotes_Header_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID,
		@LOG_SHP_ReturnShipment_CreditNotes_Header_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)