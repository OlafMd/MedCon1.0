UPDATE 
	log_shp_shipment_statushistory
SET 
	LOG_SHP_Shipment_Header_RefID=@LOG_SHP_Shipment_Header_RefID,
	LOG_SHP_Shipment_Status_RefID=@LOG_SHP_Shipment_Status_RefID,
	PerformedBy_BusinessParticipant_RefID=@PerformedBy_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_SHP_Shipment_StatusHistoryID = @LOG_SHP_Shipment_StatusHistoryID