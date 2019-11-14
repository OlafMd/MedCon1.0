UPDATE 
	log_shp_shipmentposition_2_deliveryposition
SET 
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	LOG_DLV_Delivery_Position_RefID=@LOG_DLV_Delivery_Position_RefID,
	DeliveryQuantity=@DeliveryQuantity,
	Shiped_TrackingInstance_RefID=@Shiped_TrackingInstance_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID