UPDATE 
	log_shp_returnshipment_headers
SET 
	Ext_Shipment_Header_RefID=@Ext_Shipment_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_SHP_ReturnShipment_HeaderID = @LOG_SHP_ReturnShipment_HeaderID