UPDATE 
	log_shp_returnshipment_receivablecreditnote_positions
SET 
	LOG_SHP_ReturnShipment_CreditNotes_Header_RefID=@LOG_SHP_ReturnShipment_CreditNotes_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID = @LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID