UPDATE 
	log_dlv_delivery_positions
SET 
	DeliveryHeader_RefID=@DeliveryHeader_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_DLV_Delivery_PositionID = @LOG_DLV_Delivery_PositionID