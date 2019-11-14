UPDATE 
	log_dlv_delivery_headers
SET 
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_DLV_Delivery_HeaderID = @LOG_DLV_Delivery_HeaderID